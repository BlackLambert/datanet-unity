using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Serialization.String
{
	public abstract class StringSerializer 
	{
		public abstract string Serialize<TSerializable>(TSerializable serializable);
		public abstract TSerializable Deserialize<TSerializable>(string serialized);
	}
}