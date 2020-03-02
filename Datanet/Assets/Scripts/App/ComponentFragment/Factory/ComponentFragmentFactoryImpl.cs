using System;

namespace SBaier.Datanet.Core
{
	public class ComponentFragmentFactoryImpl : ComponentFragmentFactory
	{
		public override ComponentFragment Create(ComponentFragmentTemplate template)
		{
			if (template is TextFragmentTemplate)
				return createTextFragment((TextFragmentTemplate)template);
			if (template is DateFragmentTemplate)
				return createDateFragment((DateFragmentTemplate)template);
			throw new NotImplementedException($"The template of type {template.GetType()} is unknown to the {nameof(ComponentFragmentFactoryImpl)}.");
		}


		private TextFragment createTextFragment(TextFragmentTemplate template)
		{
			return new TextFragment(Guid.NewGuid(), template);
		}

		private DateFragment createDateFragment(DateFragmentTemplate template)
		{
			return new DateFragment(Guid.NewGuid(), template);
		}
	}
}