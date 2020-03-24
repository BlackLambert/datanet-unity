using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBaier.Persistence
{
	public class CollectiveDataSaver : DataSaver
	{
		private HashSet<DataSaver> _savers = new HashSet<DataSaver>();
		public HashSet<DataSaver> SaversCopy { get { return new HashSet<DataSaver>( _savers); } }

		public void Add(DataSaver saver)
		{
			validateArgument(saver);
			if (_savers.Contains(saver))
				throw new ArgumentException("Adding a loader that has already been added is not allowed.");
			_savers.Add(saver);
		}

		public void Remove(DataSaver saver)
		{
			validateArgument(saver);
			if (!_savers.Contains(saver))
				throw new ArgumentException("Removing a loader that has not been added before is not possibe.");
			_savers.Remove(saver);
		}

		private void validateArgument(DataSaver saver)
		{
			if (saver == null)
				throw new ArgumentNullException($"The argument is not allowed to be null");
			if (saver == this)
				throw new ArgumentException($"The argument is not allowed to be this loader");
		}

		public async Task Save()
		{
			foreach (DataSaver saver in _savers)
				await saver.Save();
		}
	}
}