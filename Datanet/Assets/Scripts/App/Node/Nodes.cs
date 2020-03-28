using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Nodes : BasicDictionaryData<Guid, Node>
	{
		public void Add(Node node)
		{
			Add(node.ID, node);
		}

		public override string ToString()
		{
			string result = "Nodes: (";
			foreach (Node node in CopyDictionary().Values)
				result += node.ToString();
			return result + ")";
		}
	}
}