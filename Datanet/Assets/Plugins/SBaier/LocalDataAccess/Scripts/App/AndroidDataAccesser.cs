using System.Threading.Tasks;
using UnityEngine.Networking;

namespace SBaier.LocalDataAccess
{
	public class AndroidDataAccesser : LocalDataAccesser
	{
		protected async override Task<string> load(string path)
		{
			using (UnityWebRequest www = UnityWebRequest.Get(path))
			{
				await www.SendWebRequest();
				return www.downloadHandler.text;
			}
		}

		protected async override Task save(string path, string content)
		{
			byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);
			using (UnityWebRequest www = UnityWebRequest.Put(path, contentBytes))
			{
				await www.SendWebRequest();
			}
		}
	}
}