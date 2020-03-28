using System;

namespace SBaier.Datanet
{
	
	public class NodeDatas : BasicDictionaryData<Guid, NodeData>
	{
		public void Add(NodeData nodeData)
		{
			Add(nodeData.ID, nodeData);
		}
	}
}