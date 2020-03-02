using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public class NodeTypeRepositoryImpl : BasicDictionaryRepository<Guid, NodeType>, NodeTypeRepository
	{
		public void Add(NodeType nodeTypeToAdd)
		{
			Add(nodeTypeToAdd.ID, nodeTypeToAdd);
		}
	}
}