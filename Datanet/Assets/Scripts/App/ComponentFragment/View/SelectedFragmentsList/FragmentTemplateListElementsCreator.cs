using SBaier.UI.List;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateListElementsCreator : ListElementsCreator<FragmentTemplatesOfComponent, Guid, FragmentTemplateListElementInstaller>
	{
		private ComponentFragmentTemplatesRepository _templatesRepository;


		[Inject]
		private void Construct(ComponentFragmentTemplatesRepository templatesRepository)
		{
			_templatesRepository = templatesRepository;
		}


		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(Guid data)
		{
			ComponentFragmentTemplate template = _templatesRepository.Get().Get(data);
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(template, typeof(ComponentFragmentTemplate)) };
		}
	}
}