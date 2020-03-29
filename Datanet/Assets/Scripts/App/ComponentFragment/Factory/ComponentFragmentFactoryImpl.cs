using SBaier.Storage;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentFragmentFactoryImpl : ComponentFragmentFactory
	{
		private Repository<ComponentFragmentTemplates> _templatesRepository;
		public ComponentFragmentTemplates Tempaltes { get { return _templatesRepository.Get(); } }

		private Repository<ComponentFragmentDatas> _datasRepository;
		public ComponentFragmentDatas Datas { get { return _datasRepository.Get(); } }

		private Repository<ComponentFragments> _fragmentsRepository;
		public ComponentFragments Fragments { get { return _fragmentsRepository.Get(); } }

		private Repository<FragmentInfos> _fragmentInfosRepository;
		public FragmentInfos Infos { get { return _fragmentInfosRepository.Get(); } }

		[Inject]
		private void Construct(Repository<ComponentFragmentTemplates> templatesRepository,
			Repository<ComponentFragmentDatas> datasRepository,
			Repository<ComponentFragments> fragmentsRepository,
			Repository<FragmentInfos> fragmentInfosRepository)
		{
			_templatesRepository = templatesRepository;
			_datasRepository = datasRepository;
			_fragmentsRepository = fragmentsRepository;
			_fragmentInfosRepository = fragmentInfosRepository;
		}

		public override ComponentFragment CreateByTemplate(Guid templateID)
		{
			ComponentFragmentTemplate template = getTemplate(templateID);
			ComponentFragment result = createFragment(template);
			storeFragment(result);
			return result;
		}

		public override ComponentFragment CreateByData(Guid dataID)
		{
			ComponentFragmentData data = getData(dataID);
			ComponentFragmentTemplate template = getTemplate(data.ID);
			ComponentFragment result = createFragment(template, data);
			storeFragment(result);
			return result;
		}

		private ComponentFragmentTemplate getTemplate(Guid templateID)
		{
			checkTemplatesLoaded();
			return Tempaltes.Get(templateID);
		}

		private ComponentFragmentData getData(Guid dataID)
		{
			checkDatasLoaded();
			return Datas.Get(dataID);
		}

		private void storeFragment(ComponentFragment fragment)
		{
			checkFragmentsLoaded();
			Fragments.Add(fragment);
		}

		private ComponentFragment createFragment(ComponentFragmentTemplate template, ComponentFragmentData data = null)
		{
			checkFragmentInfosLoaded();
			if (template is TextFragmentTemplate)
				return createTextFragment((TextFragmentTemplate)template, (TextFragmentData)data);
			throw new NotImplementedException($"The template of type {template.GetType()} is unknown to the {nameof(ComponentFragmentFactoryImpl)}.");
		}

		private TextFragment createTextFragment(TextFragmentTemplate template, TextFragmentData data)
		{
			if (data == null)
				data = createTextDataFragmentData(template);
			return new TextFragment(data, template, Infos.Get(ComponentFragmentType.Text));
		}

		private TextFragmentData createTextDataFragmentData(TextFragmentTemplate template)
		{
			checkDatasLoaded();
			TextFragmentData data = new TextFragmentData(Guid.NewGuid(), template.ID, template.DefaultValue);
			Datas.Add(data);
			return data;
		}



		private void checkDatasLoaded()
		{
			if (Datas == null)
				throw new InvalidOperationException($"Failed to create {nameof(ComponentFragment)}. The {nameof(ComponentFragmentDatas)} have not been loaded yet.");
		}

		private void checkTemplatesLoaded()
		{
			if (Tempaltes == null)
				throw new InvalidOperationException($"Failed to create {nameof(ComponentFragment)}. The {nameof(ComponentFragmentTemplates)} have not been loaded yet.");
		}

		private void checkFragmentsLoaded()
		{
			if (Fragments == null)
				throw new InvalidOperationException($"Failed to create {nameof(ComponentFragment)}. The {nameof(ComponentFragments)} have not been loaded yet.");
		}

		private void checkFragmentInfosLoaded()
		{
			if (Fragments == null)
				throw new InvalidOperationException($"Failed to create {nameof(FragmentInfo)}. The {nameof(FragmentInfos)} have not been loaded yet.");
		}
	}
}