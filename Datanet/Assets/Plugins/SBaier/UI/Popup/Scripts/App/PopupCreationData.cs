

namespace SBaier.UI.Popup
{
	public class PopupCreationData 
	{
		public PopupInstaller PopupPrefab { get; private set; }
		public PopupStructure PopupStructure { get; private set; }
		public PopupContent PopupContent { get; private set; }

		public PopupCreationData(PopupInstaller popupPrefab,
			PopupStructure popupStructure,
			PopupContent popupContent)
		{
			PopupPrefab = popupPrefab;
			PopupStructure = popupStructure;
			PopupContent = popupContent;
		}
	}
}