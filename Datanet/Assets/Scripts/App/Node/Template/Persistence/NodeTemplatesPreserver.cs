using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class NodeTemplatesPreserver : LocalDataPreserver<NodeTemplates>
	{
		public NodeTemplatesPreserver(string path, 
			StringSerializer serializer,
			LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}