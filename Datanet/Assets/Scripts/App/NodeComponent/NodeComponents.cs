using System;

namespace SBaier.Datanet
{
	public class NodeComponents : BasicDictionaryData<Guid, NodeComponent>
	{
		public void Add(NodeComponent nodeComponent)
		{
			Add(nodeComponent.ID, nodeComponent);
		}
	}
}