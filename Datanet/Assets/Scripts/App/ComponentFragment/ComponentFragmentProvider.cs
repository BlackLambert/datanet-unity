using SBaier.Storage;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentFragmentProvider 
	{
		private Repository<ComponentFragments> _fragmentsRepository;
		public ComponentFragments Fragments { get { return _fragmentsRepository.Get(); } }
		private ComponentFragmentFactory _fragmentFactory;

		[Inject]
		private void Construct(
			Repository<ComponentFragments> fragmentsRepository,
			ComponentFragmentFactory fragmentFactory)
		{
			_fragmentsRepository = fragmentsRepository;
			_fragmentFactory = fragmentFactory;
		}

		public ComponentFragment Get(Guid fragmentID)
		{
			checkFragmentsLoaded();
			if (Fragments.Contains(fragmentID))
				return Fragments.Get(fragmentID);
			return _fragmentFactory.CreateByData(fragmentID);
		}

		private void checkFragmentsLoaded()
		{
			if (Fragments == null)
				throw new InvalidOperationException($"Failed to create {nameof(ComponentFragment)}. The {nameof(ComponentFragments)} have not been loaded yet.");
		}
	}
}