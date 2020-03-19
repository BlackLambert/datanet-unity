using SBaier.Persistence;
using SBaier.Storage;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class DataNetsSaver : RepositorySaver<DataNets>
	{
		public DataNetsSaver(Repository<DataNets> repository,
			DataPreserver<DataNets> preserver) : base(repository, preserver)
		{
		}
	}
}