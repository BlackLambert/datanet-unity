using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public class NodeComponentTypeRepositoryImpl : BasicDictionaryRepository<Guid, NodeComponentType>, NodeComponentTypeRepository
	{
		public void Add(NodeComponentType type)
		{
			Add(type.ID, type);
		}
	}
}