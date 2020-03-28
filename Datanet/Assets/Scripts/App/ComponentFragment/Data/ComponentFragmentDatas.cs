using System;

namespace SBaier.Datanet
{
	public class ComponentFragmentDatas : BasicDictionaryData<Guid, ComponentFragmentData>
	{
		public void Add(ComponentFragmentData data)
		{
			Add(data.ID, data);
		}
	}
}