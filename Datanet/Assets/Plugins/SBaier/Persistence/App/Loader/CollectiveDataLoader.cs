using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SBaier.Persistence
{
	public class CollectiveDataLoader : DataLoader
	{
		private HashSet<DataLoader> _loaders = new HashSet<DataLoader>();
		public HashSet<DataLoader> LoadersCopy { get { return new HashSet<DataLoader>(_loaders); } }

		public void Add(DataLoader loader)
		{
			validateArgument(loader);
			if (_loaders.Contains(loader))
				throw new ArgumentException("Adding a loader that has already been added is not allowed.");
			_loaders.Add(loader);
		}

		public void Remove(DataLoader loader)
		{
			validateArgument(loader);
			if (!_loaders.Contains(loader))
				throw new ArgumentException("Removing a loader that has not been added before is not possibe.");
			_loaders.Remove(loader);
		}

		private void validateArgument(DataLoader loader)
		{
			if (loader == null)
				throw new ArgumentNullException($"The argument is not allowed to be null");
			if (loader == this)
				throw new ArgumentException($"The argument is not allowed to be this loader");
		}

		public async Task Load()
		{
			foreach (DataLoader loader in _loaders)
				await loader.Load();
		}
	}
}