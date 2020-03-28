

using SBaier.Storage;
using System;
using System.Collections.Generic;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeFactoryImpl : NodeFactory
	{
		private Repository<NodeTemplates> _templatesRepository;
		public NodeTemplates Tempaltes { get { return _templatesRepository.Get(); } }

		private Repository<NodeDatas> _datasRepository;
		public NodeDatas Datas { get { return _datasRepository.Get(); } }

		private Repository<Nodes> _nodesRepository;
		public Nodes Nodes { get { return _nodesRepository.Get(); } }

		private NodeComponentFactory _componentFactory;


		[Inject]
		private void Construct(Repository<NodeTemplates> templatesRepository,
			Repository<NodeDatas> datasRepository,
			Repository<Nodes> nodesRepository,
			NodeComponentFactory componentFactory)
		{
			_templatesRepository = templatesRepository;
			_datasRepository = datasRepository;
			_nodesRepository = nodesRepository;
			_componentFactory = componentFactory;
		}

		public Node CreateByData(Guid dataID)
		{
			NodeData data = getData(dataID);
			NodeTemplate template = getTemplate(data.ID);
			Node result = new Node(data, template);
			storeNode(result);
			return result;
		}

		public Node CreateByTempalte(Guid templateID)
		{
			NodeTemplate template = getTemplate(templateID);
			HashSet<Guid> componentIDs = new HashSet<Guid>();
			foreach (Guid iD in template.ComponentTemplatesCopy)
			{
				NodeComponent component = _componentFactory.CreateByTemplate(iD);
				componentIDs.Add(component.ID);
			}
			NodeData data = createNodeData(template, componentIDs);
			Node result = new Node(data, template);
			storeNode(result);
			return result;
		}


		private NodeTemplate getTemplate(Guid templateID)
		{
			checkTemplatesLoaded();
			return Tempaltes.Get(templateID);
		}

		private NodeData getData(Guid dataID)
		{
			checkDatasLoaded();
			return Datas.Get(dataID);
		}

		private void storeNode(Node component)
		{
			checkNodesLoaded();
			Nodes.Add(component);
		}


		private NodeData createNodeData(NodeTemplate template, HashSet<Guid> componentIDs)
		{
			checkDatasLoaded();
			NodeData data = new NodeData(Guid.NewGuid(), template.ID, componentIDs);
			Datas.Add(data);
			return data;
		}



		private void checkDatasLoaded()
		{
			if (Datas == null)
				throw new InvalidOperationException($"Failed to create {nameof(Node)}. The {nameof(NodeDatas)} have not been loaded yet.");
		}

		private void checkTemplatesLoaded()
		{
			if (Tempaltes == null)
				throw new InvalidOperationException($"Failed to create {nameof(Node)}. The {nameof(NodeTemplates)} have not been loaded yet.");
		}

		private void checkNodesLoaded()
		{
			if (Nodes == null)
				throw new InvalidOperationException($"Failed to create {nameof(Node)}. The {nameof(Nodes)} have not been loaded yet.");
		}
	}
}