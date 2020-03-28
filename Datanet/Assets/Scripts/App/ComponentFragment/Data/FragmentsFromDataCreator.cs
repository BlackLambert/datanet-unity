using SBaier.Storage;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentsFromDataCreator : MonoBehaviour
	{
		private Repository<ComponentFragmentDatas> _fragmentDatasRepository;
		public ComponentFragmentDatas Datas { get { return _fragmentDatasRepository.Get(); } }
		private ComponentFragmentFactory _fragmentFactory;

		[Inject]
		private void Construct(Repository<ComponentFragmentDatas> fragmentDatasRepository,
			ComponentFragmentFactory fragmentFactory)
		{
			_fragmentDatasRepository = fragmentDatasRepository;
			_fragmentFactory = fragmentFactory;
		}

		protected virtual void Start()
		{
			if (Datas != null)
				createFragments();
			_fragmentDatasRepository.OnRepositoryDataChanged += onRepositoryDataChanged;
		}

		protected virtual void OnDestroy()
		{
			_fragmentDatasRepository.OnRepositoryDataChanged -= onRepositoryDataChanged;
		}

		private void onRepositoryDataChanged(ComponentFragmentDatas former, ComponentFragmentDatas newData)
		{
			createFragments();
		}

		private void createFragments()
		{
			foreach (ComponentFragmentData data in Datas.CopyDictionary().Values)
				_fragmentFactory.CreateByData(data.ID);
		}
	}
}