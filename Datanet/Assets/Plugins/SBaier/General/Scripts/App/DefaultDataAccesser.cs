using System.IO;
using System.Threading.Tasks;

namespace SBaier
{
	public class DefaultDataAccesser : LocalDataAccesser
	{
		protected override async Task save(string path, string serializedData)
		{
			byte[] content = System.Text.Encoding.UTF8.GetBytes(serializedData);
			using (FileStream stream = File.Create(path))
			{
				await stream.WriteAsync(content, 0, content.Length);
			}
		}

		protected override async Task<string> load(string path)
		{
			byte[] readresult;
			using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
			{
				readresult = new byte[stream.Length];
				await stream.ReadAsync(readresult, 0, readresult.Length);
			}
			return System.Text.Encoding.UTF8.GetString(readresult);
		}
	}
}