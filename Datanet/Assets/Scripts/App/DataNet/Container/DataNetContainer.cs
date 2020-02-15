

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public abstract class DataNetContainer
	{
		public abstract event Action<DataNet> OnNetAdded;
		public abstract event Action<DataNet> OnNetRemoved;
		public abstract int Count { get; }
		public abstract IEnumerable<DataNet> DataNetsCopy { get; }
		public abstract void AddDataNet(DataNet value);
		public abstract DataNet GetDataNet(Guid iD);
		public abstract void RemoveDataNet(Guid iD);
		public abstract bool Contains(Guid iD);
	}
}