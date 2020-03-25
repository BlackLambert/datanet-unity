using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI
{
	public abstract class CloseViewOnClick<TView> : MonoBehaviour where TView : View
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		protected abstract TView ViewToClose { get; }
		protected abstract Transform ViewToCloseBase { get; }

		private ViewDisplayer<TView> _viewDisplayer;

		[Inject]
		private void Construct(
			ViewDisplayer<TView> viewDisplayer)
		{
			_viewDisplayer = viewDisplayer;
		}

		protected virtual void Start()
		{
			Button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			Button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			hidePage();
		}

		private void hidePage()
		{
			ViewToClose.OnHidden += destroyPage;
			_viewDisplayer.Hide(ViewToClose);
		}

		private void destroyPage()
		{
			ViewToClose.OnHidden -= destroyPage;
			Destroy(ViewToCloseBase.gameObject);
		}
	}
}