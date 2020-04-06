using SBaier.LocalDataAccess;
using SBaier.Persistence;
using SBaier.Serialization.String;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplatesPreserver : LocalDataPreserver<ComponentFragmentTemplates>
	{
		public ComponentFragmentTemplatesPreserver(string path, StringSerializer serializer, LocalDataAccesser localDataAccesser) : base(path, serializer, localDataAccesser)
		{
		}
	}
}