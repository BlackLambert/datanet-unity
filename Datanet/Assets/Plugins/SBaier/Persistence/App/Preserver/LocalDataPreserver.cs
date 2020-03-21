using System;
using System.Threading.Tasks;
using SBaier.Serialization.String;

namespace SBaier.Persistence
{
	public abstract class LocalDataPreserver<TData> : DataPreserver<TData>
	{
		private string _dataPath;
		private StringSerializer _serializer;
		private LocalDataAccesser _localDataAccesser;


		public LocalDataPreserver(string path,
			StringSerializer serializer,
			LocalDataAccesser localDataAccesser)
		{
			_dataPath = path;
			_serializer = serializer;
			_localDataAccesser = localDataAccesser;
		}


		public async Task Preserve(TData data)
		{
			if (data == null)
				throw new ArgumentNullException();
			string serializedData = string.Empty;
			serializedData = _serializer.Serialize(data);

			await _localDataAccesser.Save(_dataPath, serializedData);
		}

		public async Task<TData> Retrieve()
		{
			string serializedData = await _localDataAccesser.Load(_dataPath);
			TData result = _serializer.Deserialize<TData>(serializedData);
			return result;
		}
	}
}