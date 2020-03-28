using System;

namespace SBaier.Datanet
{
	public class NodeComponentDatas : BasicDictionaryData<Guid, NodeComponentData>
	{
		public void Add(NodeComponentData data)
		{
			Add(data.ID, data);
		}
	}
}