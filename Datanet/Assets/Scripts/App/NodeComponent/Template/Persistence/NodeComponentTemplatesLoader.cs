using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeComponentTemplatesLoader : ToRepositoryLoader<NodeComponentTemplates>
	{
		public NodeComponentTemplatesLoader(Repository<NodeComponentTemplates> repository, DataPreserver<NodeComponentTemplates> preserver) : base(repository, preserver)
		{
		}

		protected override NodeComponentTemplates createNew()
		{
			return new NodeComponentTemplates();
		}
	}
}