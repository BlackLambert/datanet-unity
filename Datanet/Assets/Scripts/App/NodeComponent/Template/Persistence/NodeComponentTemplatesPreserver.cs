using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class NodeComponentTemplatesPreserver : LocalDataPreserver<NodeComponentTemplates>
	{
		public NodeComponentTemplatesPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}