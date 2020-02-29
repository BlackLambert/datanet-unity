using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Popup
{
	public abstract class ShowPopupButton : MonoBehaviour
	{
		private PopupFactory _popupFactory;

		protected abstract PopupInstaller PopupPrefab { get; }
		protected abstract PopupStructure StructurePrefab { get; }
		protected abstract PopupContent ContentPrefab { get; }

		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		[Inject]
		private void Construct(PopupFactory popupFactory)
		{
			_popupFactory = popupFactory;
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

		private PopupCreationData createCreationData()
		{
			return new PopupCreationData(PopupPrefab, StructurePrefab, ContentPrefab);
		}

		private void createPopup()
		{
			_popupFactory.Create(createCreationData());
		}
	}
}
