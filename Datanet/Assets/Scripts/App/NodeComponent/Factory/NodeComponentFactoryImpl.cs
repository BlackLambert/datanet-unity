using SBaier.Storage;
using System;
using System.Collections.Generic;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeComponentFactoryImpl : NodeComponentFactory
	{
		private Repository<NodeComponentTemplates> _templatesRepository;
		public NodeComponentTemplates Tempaltes { get { return _templatesRepository.Get(); } }

		private Repository<NodeComponentDatas> _datasRepository;
		public NodeComponentDatas Datas { get { return _datasRepository.Get(); } }

		private Repository<NodeComponents> _fragmentsRepository;
		public NodeComponents Components { get { return _fragmentsRepository.Get(); } }

		private ComponentFragmentFactory _fragementFactory;


		[Inject]
		private void Construct(Repository<NodeComponentTemplates> templatesRepository,
			Repository<NodeComponentDatas> datasRepository,
			Repository<NodeComponents> nodesRepository,
			ComponentFragmentFactory fragementFactory)
		{
			_templatesRepository = templatesRepository;
			_datasRepository = datasRepository;
			_fragmentsRepository = nodesRepository;
			_fragementFactory = fragementFactory;
		}

		public NodeComponent CreateByData(Guid dataID)
		{
			NodeComponentData data = getData(dataID);
			NodeComponentTemplate template = getTemplate(data.ID);
			NodeComponent result = new NodeComponent(template, data);
			storeComponent(result);
			return result;
		}

		public NodeComponent CreateByTemplate(Guid templateID)
		{
			NodeComponentTemplate template = getTemplate(templateID);
			HashSet<Guid> fragmentIDs = new HashSet<Guid>();
			foreach(Guid iD in template.FragmentTemplateIDsCopy)
			{
				ComponentFragment fragment = _fragementFactory.CreateByTemplate(iD);
				fragmentIDs.Add(fragment.ID);
			}
			NodeComponentData data = createComponentData(template, fragmentIDs);
			NodeComponent result = new NodeComponent(template, data);
			storeComponent(result);
			return result;
		}


		private NodeComponentTemplate getTemplate(Guid templateID)
		{
			checkTemplatesLoaded();
			return Tempaltes.Get(templateID);
		}

		private NodeComponentData getData(Guid dataID)
		{
			checkDatasLoaded();
			return Datas.Get(dataID);
		}

		private void storeComponent(NodeComponent component)
		{
			checkComponentsLoaded();
			Components.Add(component);
		}


		private NodeComponentData createComponentData(NodeComponentTemplate template, HashSet<Guid> fragmentIDs)
		{
			checkDatasLoaded();
			NodeComponentData data = new NodeComponentData(Guid.NewGuid(), template.ID, fragmentIDs);
			Datas.Add(data);
			return data;
		}



		private void checkDatasLoaded()
		{
			if (Datas == null)
				throw new InvalidOperationException($"Failed to create {nameof(NodeComponent)}. The {nameof(NodeComponentDatas)} have not been loaded yet.");
		}

		private void checkTemplatesLoaded()
		{
			if (Tempaltes == null)
				throw new InvalidOperationException($"Failed to create {nameof(NodeComponent)}. The {nameof(NodeComponentTemplates)} have not been loaded yet.");
		}

		private void checkComponentsLoaded()
		{
			if (Components == null)
				throw new InvalidOperationException($"Failed to create {nameof(NodeComponent)}. The {nameof(NodeComponents)} have not been loaded yet.");
		}
	}
}