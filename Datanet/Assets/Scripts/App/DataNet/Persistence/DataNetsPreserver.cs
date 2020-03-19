﻿using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet.Core
{
	public class DataNetsPreserver : LocalDataPreserver<DataNets>
	{
		

		public DataNetsPreserver(string path, StringSerializer serializer) : base(path, serializer)
		{
		}
	}
}