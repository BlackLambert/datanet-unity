using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public interface NodeTypeRepository : IDictionaryRepository<Guid, NodeType>
	{
		void Add(NodeType nodeTypeToAdd);
	}
}