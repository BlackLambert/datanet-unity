using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI.Popup
{
	public class ClosePopupOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		private PopupInstaller _popupInstaller;
		private PopupViewDisplayer _popupDisplayer;

		[Inject]
		private void Construct(PopupInstaller popupInstaller,
			PopupViewDisplayer popupDisplayer)
		{
			_popupInstaller = popupInstaller;
			_popupDisplayer = popupDisplayer;
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
			hidePopup();
		}

		private void hidePopup()
		{
			_popupDisplayer.Hide(_popupInstaller.Popup);
			_popupInstaller.Popup.OnHidden += destroyPopup;
		}

		private void destroyPopup()
		{
			_popupInstaller.Popup.OnHidden -= destroyPopup;
			Destroy(_popupInstaller.Base.gameObject);
		}
	}
}