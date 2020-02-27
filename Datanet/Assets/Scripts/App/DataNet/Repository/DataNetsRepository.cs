

using System;
using System.Collections.Generic;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public interface DataNetsRepository : IDictionaryRepository<Guid, DataNet>
	{
		void Add(DataNet net);
	}
}