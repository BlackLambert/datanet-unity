using System;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplateFactoryImpl : ComponentFragmentTemplateFactory
	{
		private const string _defaultText = "New Text";

		public override ComponentFragmentTemplate Create(ComponentFragmentType type)
		{
			switch(type)
			{
				case ComponentFragmentType.Text:
					return new TextFragmentTemplate(Guid.NewGuid(), _defaultText, false);
				case ComponentFragmentType.None:
					throw new ArgumentNullException($"The type {ComponentFragmentType.None} is not allowed.");
				default:
					throw new ArgumentException($"The template of type {type} has not been implemented yet");
			}
		}
	}
}