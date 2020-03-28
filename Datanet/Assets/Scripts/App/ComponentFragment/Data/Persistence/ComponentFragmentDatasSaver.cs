using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class ComponentFragmentDatasSaver : RepositorySaver<ComponentFragmentDatas>
	{
		public ComponentFragmentDatasSaver(Repository<ComponentFragmentDatas> repository, DataPreserver<ComponentFragmentDatas> preserver) : base(repository, preserver)
		{
		}
	}
}