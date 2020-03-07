using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public class NodesRepositoryImp : BasicDictionaryRepository<Guid, Node>, NodesRepository
	{
		public void Add(Node node)
		{
			Add(node.ID, node);
		}
	}
}