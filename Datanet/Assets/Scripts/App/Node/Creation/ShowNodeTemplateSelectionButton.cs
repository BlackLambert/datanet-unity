using SBaier.Popup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class ShowNodeTemplateSelectionButton : MonoBehaviour
	{
		private PopupFactory _popupFactory;
		private PopupResourcePaths _popupResourcePaths;

		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		[Inject]
		private void Construct(PopupFactory popupFactory,
			PopupResourcePaths popupResourcePaths)
		{
			_popupFactory = popupFactory;
			_popupResourcePaths = popupResourcePaths;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			createPopup();
		}

		private void createPopup()
		{
			PopupInstaller popupBasePrefab = (Resources.Load(_popupResourcePaths.PopupBase) as GameObject).GetComponent<PopupInstaller>();
			PopupStructure popupStructure = (Resources.Load(_popupResourcePaths.ClosablePopupStructure) as GameObject).GetComponent<PopupStructure>();
			PopupContent popupContent = (Resources.Load(ResourcePaths.NodeTemplateSelectionPopupContent) as GameObject).GetComponent<PopupContent>();
			_popupFactory.Create(new PopupCreationData(popupBasePrefab, popupStructure, popupContent));
		}
	}
}