

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class DataNetContainer
	{
		private Dictionary<Guid, DataNet> _idToDataNet;
		public event Action<DataNet> OnNetAdded;
		public event Action<DataNet> OnNetRemoved;
		public int Count { get { return _idToDataNet.Count; } }

		public DataNetContainer()
		{
			_idToDataNet = new Dictionary<Guid, DataNet>();
		}

		public void AddDataNet(DataNet value)
		{
			_idToDataNet.Add(value.ID, value);
			OnNetAdded?.Invoke(value);
		}

		public DataNet GetDataNet(Guid iD)
		{
			throw new NotImplementedException();
		}

		public void RemoveDataNet(Guid iD)
		{
			DataNet netToRemove = _idToDataNet[iD];
			_idToDataNet.Remove(iD);
			OnNetRemoved?.Invoke(netToRemove);
		}
	}
}