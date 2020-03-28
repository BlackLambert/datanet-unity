using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeComponentDatasSaver : RepositorySaver<NodeComponentDatas>
	{
		public NodeComponentDatasSaver(Repository<NodeComponentDatas> repository, DataPreserver<NodeComponentDatas> preserver) : base(repository, preserver)
		{
		}
	}
}