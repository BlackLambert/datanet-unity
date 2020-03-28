using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplatesLoader : ToRepositoryLoader<ComponentFragmentTemplates>
	{
		public ComponentFragmentTemplatesLoader(Repository<ComponentFragmentTemplates> repository, DataPreserver<ComponentFragmentTemplates> preserver) : base(repository, preserver)
		{
		}

		protected override ComponentFragmentTemplates createNew()
		{
			return new ComponentFragmentTemplates();
		}
	}
}