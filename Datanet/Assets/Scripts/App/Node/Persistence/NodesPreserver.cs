using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet.Core
{
	public class NodesPreserver : LocalDataPreserver<Nodes>
	{
		public NodesPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}