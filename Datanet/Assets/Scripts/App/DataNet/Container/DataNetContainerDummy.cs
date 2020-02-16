

using System;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public class DataNetContainerDummy : DataNetContainer
	{
		private const string _netName = "My Net";

		public override int Count => 0;

		public override IEnumerable<DataNet> DataNetsCopy => new List<DataNet>();

		public override event Action<DataNet> OnNetAdded;
		public override event Action<DataNet> OnNetRemoved;

		public override void Add(DataNet value)
		{
			Debug.Log("Adding net to dummy container");
			OnNetAdded?.Invoke(value);
		}

		public override bool Contains(Guid iD)
		{
			Debug.Log("Checking if dummy container contains net");
			return true;
		}

		public override DataNet Get(Guid iD)
		{
			return new DataNetFactoryDummy().Create(new DataNetFactory.Parameter(iD, _netName));
		}

		public override void Remove(Guid iD)
		{
			Debug.Log("Removing net from dummy container");
			OnNetRemoved?.Invoke(new DataNetFactoryDummy().Create(new DataNetFactory.Parameter(iD, _netName)));
		}
	}
}