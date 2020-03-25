
using SBaier.Persistence;
using SBaier.Datanet.Core;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeTemplatesLoader : ToRepositoryLoader<NodeTemplates>
	{
		public NodeTemplatesLoader(Repository<NodeTemplates> repository, DataPreserver<NodeTemplates> preserver) : base(repository, preserver)
		{
		}

		protected override NodeTemplates createNew()
		{
			return new NodeTemplates();
		}
	}
}