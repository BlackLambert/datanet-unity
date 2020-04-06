
using SBaier.LocalDataAccess;
using SBaier.Serialization.String;

namespace SBaier.Persistence.Tests
{
	public class TestLocalDataPreserver : LocalDataPreserver<TestData>
	{
		public TestLocalDataPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}