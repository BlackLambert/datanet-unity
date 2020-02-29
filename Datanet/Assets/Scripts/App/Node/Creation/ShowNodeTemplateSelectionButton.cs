using SBaier.Popup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class ShowNodeTemplateSelectionButton : ShowPopupButton
	{
		private PopupResourcePaths _popupResourcePaths;

		protected override PopupInstaller PopupPrefab => 
			(Resources.Load(_popupResourcePaths.PopupBase) as GameObject).GetComponent<PopupInstaller>();

		protected override PopupStructure StructurePrefab =>
			(Resources.Load(_popupResourcePaths.ClosablePopupStructure) as GameObject).GetComponent<PopupStructure>();

		protected override PopupContent ContentPrefab =>
			(Resources.Load(ResourcePaths.NodeTemplateSelectionPopupContent) as GameObject).GetComponent<PopupContent>();

		[Inject]
		private void Construct(
			PopupResourcePaths popupResourcePaths)
		{
			_popupResourcePaths = popupResourcePaths;
		}
	}
}