using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class NodesLoader : ToRepositoryLoader<Nodes>
	{
		public NodesLoader(Repository<Nodes> repository, DataPreserver<Nodes> preserver) : base(repository, preserver)
		{
		}

		protected override Nodes createNew()
		{
			return new Nodes();
		}
	}
}