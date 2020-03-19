using SBaier.Storage;
using UnityEngine;
using Zenject;

namespace SBaier.UI
{
	public abstract class OnRepositoryEmptyViewDisplayer<TData> : MonoBehaviour
	{
		[SerializeField]
		private View _view = null;
		[SerializeField]
		private bool _displayOnEmpty = true;


		private Repository<TData> _repository;
		public bool ShallDisplay
		{
			get
			{
				TData data = _repository.Get();
				return _displayOnEmpty && data == null ||
					!_displayOnEmpty && data != null;
			}
		}

		[Inject]
		private void Construct(Repository<TData> repository)
		{
			_repository = repository;
		}
		
		protected virtual void Start()
		{
			_repository.OnRepositoryDataChanged += onRepositoryContentChanged;
			updateView();
		}

		protected virtual void OnDestroy()
		{
			_repository.OnRepositoryDataChanged -= onRepositoryContentChanged;
		}

		private void onRepositoryContentChanged(TData former, TData newData)
		{
			updateView();
		}

		private void updateView()
		{
			_view.Display(ShallDisplay);
		}
	}
}