using SBaier.Storage;
using System;

namespace SBaier.Datanet.Core
{
	public interface ComponentFragmentTemplateRepository : IDictionaryRepository<Guid, ComponentFragmentTemplate>
	{
		void Add(ComponentFragmentTemplate templateToAdd);
	}
}