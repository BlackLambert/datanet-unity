using System;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplates : BasicDictionaryData<Guid, ComponentFragmentTemplate>
	{
		public void Add(ComponentFragmentTemplate template)
		{
			Add(template.ID, template);
		}
	}
}