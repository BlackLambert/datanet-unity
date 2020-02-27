using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public class DataNetsRepositoryImpl : BasicDictionaryRepository<Guid, DataNet>, DataNetsRepository
	{
		public DataNetsRepositoryImpl() : base()
		{
			Store(new Dictionary<Guid, DataNet>());
		}

		public void Add(DataNet net)
		{
			Add(net.ID, net);
		}
	}
}