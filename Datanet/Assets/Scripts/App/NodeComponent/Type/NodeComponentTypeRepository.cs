using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public interface NodeComponentTypeRepository : IDictionaryRepository<Guid, NodeComponentType>
	{
		void Add(NodeComponentType type);
	}
}