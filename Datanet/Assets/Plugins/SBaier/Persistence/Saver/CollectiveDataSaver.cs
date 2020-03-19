using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBaier.Persistence
{
	public class CollectiveDataSaver : DataSaver
	{
		private HashSet<DataSaver> _savers = new HashSet<DataSaver>();

		public void Add(DataSaver saver)
		{
			_savers.Add(saver);
		}

		public void Remove(DataSaver savers)
		{
			_savers.Remove(savers);
		}


		public async Task Save()
		{
			foreach (DataSaver saver in _savers)
				await saver.Save();
		}
	}
}