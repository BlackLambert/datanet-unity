using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class NodeTypesLoader : ToRepositoryLoader<NodeTypes>
	{
		public NodeTypesLoader(Repository<NodeTypes> repository, DataPreserver<NodeTypes> preserver) : base(repository, preserver)
		{
		}

		protected override NodeTypes createNew()
		{
			return new NodeTypes();
		}
	}
}