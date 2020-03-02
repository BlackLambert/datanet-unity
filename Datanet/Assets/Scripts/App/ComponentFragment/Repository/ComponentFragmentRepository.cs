using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public interface ComponentFragmentRepository: IDictionaryRepository<Guid, ComponentFragment>
	{
		void Add(ComponentFragment fragment);
	}

}