

using SBaier.Storage;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public class DataNetsRepositoryDummy : DictionaryRepositoryDummy<Guid, DataNet>, DataNetsRepository
	{
		public void Add(DataNet net)
		{
			Add(net.ID, net);
		}
	}
}