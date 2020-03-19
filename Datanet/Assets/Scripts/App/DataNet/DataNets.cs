﻿using Newtonsoft.Json;
using System;

namespace SBaier.Datanet.Core
{
	[JsonObject(MemberSerialization.OptIn)]
	public class DataNets : BasicDictionaryData<Guid, DataNet>
	{
		public void Add(DataNet dataNet)
		{
			Add(dataNet.ID, dataNet);
		}
	}
}