using System;

namespace SBaier.Datanet
{
	public class ComponentFragments : BasicDictionaryData<Guid, ComponentFragment>
	{
		public void Add(ComponentFragment fragment)
		{
			Add(fragment.ID, fragment);
		}
	}
}