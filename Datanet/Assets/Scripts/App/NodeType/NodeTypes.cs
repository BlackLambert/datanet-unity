using Newtonsoft.Json;
using System;

namespace SBaier.Datanet.Core
{
	[JsonObject(MemberSerialization.OptIn)]
	public class NodeTypes : BasicDictionaryData<Guid, NodeType>
	{
		public void Add(NodeType nodeType)
		{
			Add(nodeType.ID, nodeType);
		}
	}
}