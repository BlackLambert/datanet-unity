using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeComponentDatasLoader : ToRepositoryLoader<NodeComponentDatas>
	{
		public NodeComponentDatasLoader(Repository<NodeComponentDatas> repository, DataPreserver<NodeComponentDatas> preserver) : base(repository, preserver)
		{
		}

		protected override NodeComponentDatas createNew()
		{
			return new NodeComponentDatas();
		}
	}
}