using System;
using System.Threading.Tasks;
using SBaier.Serialization.String;
using UnityEngine.Networking;
using System.IO;

namespace SBaier.Persistence
{
	public abstract class LocalDataPreserver<TData> : DataPreserver<TData>
	{
		private const string _jarPathPrefix = "://";

		private string _dataPath;
		private StringSerializer _serializer;


		public LocalDataPreserver(string path,
			StringSerializer serializer)
		{
			_dataPath = path;
			_serializer = serializer;
		}


		public async Task Preserve(TData data)
		{
			if (data == null)
				throw new ArgumentNullException();

			string serializedData = string.Empty;
			serializedData = _serializer.Serialize(data);

			Directory.CreateDirectory(Path.GetDirectoryName(_dataPath));

			if (_dataPath.Contains(_jarPathPrefix))
				await saveToStreamingAssetsJar(serializedData);
			else
				await save(serializedData);
		}

		public async Task<TData> Retrieve()
		{
			string serializedData;
			if (_dataPath.Contains(_jarPathPrefix))
				serializedData = await loadStreamingAssetsJar();
			else
			{
				if(!File.Exists(_dataPath))
					return default;
				serializedData = await load();
			}

			TData result = _serializer.Deserialize<TData>(serializedData);
			return result;
		}

		private async Task save(string serializedData)
		{
			byte[] content = System.Text.Encoding.UTF8.GetBytes(serializedData);
			using (FileStream stream = File.Create(_dataPath))
			{
				await stream.WriteAsync(content, 0, content.Length);
			}
		}

		private async Task<string> load()
		{
			byte[] readresult;
			using (FileStream stream = new FileStream(_dataPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
			{
				readresult = new byte[stream.Length];
				await stream.ReadAsync(readresult, 0, readresult.Length);
			}
			return System.Text.Encoding.UTF8.GetString(readresult);
		}

		private async Task<string> loadStreamingAssetsJar()
		{
			using (UnityWebRequest www = UnityWebRequest.Get(_dataPath))
			{
				await www.SendWebRequest();
				return www.downloadHandler.text;
			}
		}

		private async Task saveToStreamingAssetsJar(string content)
		{
			byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);
			using (UnityWebRequest www = UnityWebRequest.Put(_dataPath, contentBytes))
			{
				await www.SendWebRequest();
			}
		}
	}
}