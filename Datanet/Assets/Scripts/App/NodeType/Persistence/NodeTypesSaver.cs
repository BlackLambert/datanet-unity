using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class NodeTypesSaver : RepositorySaver<NodeTypes>
	{
		public NodeTypesSaver(Repository<NodeTypes> repository, DataPreserver<NodeTypes> preserver) : base(repository, preserver)
		{
		}
	}
}