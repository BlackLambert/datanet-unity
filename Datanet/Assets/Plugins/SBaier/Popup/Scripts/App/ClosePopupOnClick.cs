using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Popup
{
	public class ClosePopupOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		private PopupInstaller _popupInstaller;

		[Inject]
		private void Construct(PopupInstaller popupInstaller)
		{
			_popupInstaller = popupInstaller;
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
			destroyPopup();
		}

		private void destroyPopup()
		{
			Destroy(_popupInstaller.Base.gameObject);
		}
	}
}