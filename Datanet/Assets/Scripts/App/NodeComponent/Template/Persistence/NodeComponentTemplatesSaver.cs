using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class NodeComponentTemplatesSaver : RepositorySaver<NodeComponentTemplates>
	{
		public NodeComponentTemplatesSaver(Repository<NodeComponentTemplates> repository, DataPreserver<NodeComponentTemplates> preserver) : base(repository, preserver)
		{
		}
	}
}