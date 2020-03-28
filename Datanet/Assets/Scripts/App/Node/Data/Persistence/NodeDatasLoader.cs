using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeDatasLoader : ToRepositoryLoader<NodeDatas>
	{
		public NodeDatasLoader(Repository<NodeDatas> repository, DataPreserver<NodeDatas> preserver) : base(repository, preserver)
		{
		}

		protected override NodeDatas createNew()
		{
			return new NodeDatas();
		}
	}
}