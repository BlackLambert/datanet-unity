using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SBaier.Persistence
{
	public class CollectiveDataLoader : DataLoader
	{
		private HashSet<DataLoader> _loaders = new HashSet<DataLoader>();

		public void Add(DataLoader loader)
		{
			_loaders.Add(loader);
		}

		public void Remove(DataLoader loader)
		{
			_loaders.Remove(loader);
		}


		public async Task Load()
		{
			foreach (DataLoader loader in _loaders)
				await loader.Load();
		}
	}
}