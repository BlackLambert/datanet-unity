using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class NodesSaver : RepositorySaver<Nodes>
	{
		public NodesSaver(Repository<Nodes> repository, DataPreserver<Nodes> preserver) : base(repository, preserver)
		{
		}
	}
}