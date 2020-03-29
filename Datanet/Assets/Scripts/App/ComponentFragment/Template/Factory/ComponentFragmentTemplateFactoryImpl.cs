using SBaier.Storage;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplateFactoryImpl : ComponentFragmentTemplateFactory
	{
		private const string _defaultText = "New Text";

		private Repository<ComponentFragmentTemplates> _templatesRepository;
		public ComponentFragmentTemplates Tempaltes { get { return _templatesRepository.Get(); } }

		[Inject]
		private void Construct(Repository<ComponentFragmentTemplates> templatesRepository)
		{
			_templatesRepository = templatesRepository;
		}

		public override ComponentFragmentTemplate Create(ComponentFragmentType type)
		{
			ComponentFragmentTemplate result = create(type);
			storeTemplate(result);
			return result;
		}

		private ComponentFragmentTemplate create(ComponentFragmentType type)
		{
			switch (type)
			{
				case ComponentFragmentType.Text:
					return new TextFragmentTemplate(Guid.NewGuid(), _defaultText, false);
				case ComponentFragmentType.None:
					throw new ArgumentNullException($"The type {ComponentFragmentType.None} is not allowed.");
				default:
					throw new ArgumentException($"The template of type {type} has not been implemented yet");
			}
		}

		private void storeTemplate(ComponentFragmentTemplate template)
		{
			checkTemplatesLoaded();
			Tempaltes.Add(template);
		}

		private void checkTemplatesLoaded()
		{
			if (Tempaltes == null)
				throw new InvalidOperationException($"Failed to create {nameof(ComponentFragment)}. The {nameof(ComponentFragmentTemplates)} have not been loaded yet.");
		}
	}
}