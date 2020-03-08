using SBaier.Storage;
using System;
using SBaier.Datanet.Core;

namespace SBaier.Datanet.Core
{
	public interface NodesRepository : IDictionaryRepository<Guid, Node>
	{
		void Add(Node node);
	}
}