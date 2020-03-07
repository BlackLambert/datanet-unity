using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI.Popup
{
	public abstract class ShowPopupButton : MonoBehaviour
	{
		private PopupFactory _popupFactory;
		private PopupViewDisplayer _popupDisplayer;

		protected abstract PopupInstaller PopupPrefab { get; }
		protected abstract PopupStructure StructurePrefab { get; }
		protected abstract PopupContent ContentPrefab { get; }

		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		[Inject]
		private void Construct(PopupFactory popupFactory,
			PopupViewDisplayer popupDisplayer)
		{
			_popupFactory = popupFactory;
			_popupDisplayer = popupDisplayer; 
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
			PopupInstaller popup = _popupFactory.Create(createCreationData());
			_popupDisplayer.Display(popup.Popup);
		}
	}
}
