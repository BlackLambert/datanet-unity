using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplatesSaver : RepositorySaver<ComponentFragmentTemplates>
	{
		public ComponentFragmentTemplatesSaver(Repository<ComponentFragmentTemplates> repository, DataPreserver<ComponentFragmentTemplates> preserver) : base(repository, preserver)
		{
		}
	}
}