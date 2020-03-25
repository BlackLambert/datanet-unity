using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI.Popup
{
	public class ClosePopupOnClick : CloseViewOnClick<Popup>
	{
		private PopupInstaller _popupInstaller;

		protected override Popup ViewToClose => _popupInstaller.Popup;

		protected override Transform ViewToCloseBase => _popupInstaller.Base;

		[Inject]
		private void Construct(PopupInstaller popupInstaller)
		{
			_popupInstaller = popupInstaller;
		}

	}
}