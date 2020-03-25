using System.Threading.Tasks;

namespace SBaier.Persistence.Tests
{
	public class TestDataSaver : DataSaver
	{
		public bool Saved { get; private set; } = false;

		public async Task Save()
		{
			await Task.Delay(1);
			Saved = true;
		}
	}
}