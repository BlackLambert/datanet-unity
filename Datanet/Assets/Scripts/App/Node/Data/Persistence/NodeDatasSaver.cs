using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeDatasSaver : RepositorySaver<NodeDatas>
	{
		public NodeDatasSaver(Repository<NodeDatas> repository, DataPreserver<NodeDatas> preserver) : base(repository, preserver)
		{
		}
	}
}