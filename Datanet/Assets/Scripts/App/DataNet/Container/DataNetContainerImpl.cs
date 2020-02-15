

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class DataNetContainerImpl : DataNetContainer
	{
		private Dictionary<Guid, DataNet> _idToDataNet;
		public override event Action<DataNet> OnNetAdded;
		public override event Action<DataNet> OnNetRemoved;
		public override int Count { get { return _idToDataNet.Count; } }
		public override IEnumerable<DataNet> DataNetsCopy { get { return new List<DataNet>(_idToDataNet.Values); } }

		public DataNetContainerImpl()
		{
			_idToDataNet = new Dictionary<Guid, DataNet>();
		}

		public override void AddDataNet(DataNet value)
		{
			_idToDataNet.Add(value.ID, value);
			OnNetAdded?.Invoke(value);
		}

		public override DataNet GetDataNet(Guid iD)
		{
			return _idToDataNet[iD];
		}

		public override void RemoveDataNet(Guid iD)
		{
			DataNet netToRemove = _idToDataNet[iD];
			_idToDataNet.Remove(iD);
			OnNetRemoved?.Invoke(netToRemove);
		}

		public override bool Contains(Guid iD)
		{
			return _idToDataNet.ContainsKey(iD);
		}
	}
}