using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class ComponentFragmentDatasLoader : ToRepositoryLoader<ComponentFragmentDatas>
	{
		public ComponentFragmentDatasLoader(Repository<ComponentFragmentDatas> repository, DataPreserver<ComponentFragmentDatas> preserver) : base(repository, preserver)
		{
		}

		protected override ComponentFragmentDatas createNew()
		{
			return new ComponentFragmentDatas();
		}
	}
}