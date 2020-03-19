using System;

namespace SBaier.Datanet.Core
{
	public class NodeComponentTypes : BasicDictionaryData<Guid, NodeComponentType>
	{
		public void Add(NodeComponentType type)
		{
			Add(type.ID, type);
		}
	}
}