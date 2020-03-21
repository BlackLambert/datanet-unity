using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace SBaier
{
	public class LocalDataAccesser
	{
		private const string _jarPathPrefix = "://";

		public async Task Save(string path, string data)
		{
			validatePath(path);
			validateData(data);
			createDirectory(path);

			if (path.Contains(_jarPathPrefix))
				await saveToStreamingAssetsJar(path, data);
			else
				await save(path, data);
		}

		public async Task<string> Load(string path)
		{
			validatePath(path);
			if (path.Contains(_jarPathPrefix))
				return await loadStreamingAssetsJar(path);
			else
			{
				if (!File.Exists(path))
					return default;
				return await load(path);
			}
		}

		private async Task save(string path, string serializedData)
		{
			byte[] content = System.Text.Encoding.UTF8.GetBytes(serializedData);
			using (FileStream stream = File.Create(path))
			{
				await stream.WriteAsync(content, 0, content.Length);
			}
		}

		private async Task<string> load(string path)
		{
			byte[] readresult;
			using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
			{
				readresult = new byte[stream.Length];
				await stream.ReadAsync(readresult, 0, readresult.Length);
			}
			return System.Text.Encoding.UTF8.GetString(readresult);
		}

		private async Task<string> loadStreamingAssetsJar(string path)
		{
			using (UnityWebRequest www = UnityWebRequest.Get(path))
			{
				await www.SendWebRequest();
				return www.downloadHandler.text;
			}
		}

		private async Task saveToStreamingAssetsJar(string path, string content)
		{
			byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);
			using (UnityWebRequest www = UnityWebRequest.Put(path, contentBytes))
			{
				await www.SendWebRequest();
			}
		}

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