using System;
using System.IO;
using System.Threading.Tasks;

namespace SBaier
{
	public abstract class LocalDataAccesser
	{
		public async Task Save(string path, string data)
		{
			validatePath(path);
			validateData(data);
			createDirectory(path);
			await save(path, data);
		}

		public async Task<string> Load(string path)
		{
			validatePath(path);
			if (!File.Exists(path))
				return string.Empty;
			return await load(path);
		}

		protected abstract Task save(string path, string serializedData);

		protected abstract Task<string> load(string path);
		

		private void createDirectory(string path)
		{
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
				Directory.CreateDirectory(directoryName);
		}

		private void validatePath(string path)
		{
			if (string.IsNullOrEmpty(path))
				throw new ArgumentNullException(path);
			if (string.IsNullOrEmpty(Path.GetExtension(path)))
				throw new ArgumentException($"The provided path {path} is a directory path. A file path is required.");
		}

		private void validateData(string data)
		{
			if (string.IsNullOrEmpty(data))
				throw new ArgumentNullException(data);
		}
	}
}