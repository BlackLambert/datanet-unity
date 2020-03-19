using System;

namespace SBaier.Datanet.Core
{
	public class Nodes : BasicDictionaryData<Guid, Node>
	{
		public void Add(Node node)
		{
			Add(node.ID, node);
		}
	}
}