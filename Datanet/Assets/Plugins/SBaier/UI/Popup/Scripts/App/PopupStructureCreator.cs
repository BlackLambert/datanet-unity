using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupStructureCreator : MonoBehaviour
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

		public PopupStructure Structure { get; private set; }

		private PopupStructure _popupStructurePrefab;
		private PrefabFactory _prefabFactory;

		[Inject]
		private void Construct(PopupStructure popupStructurePrefab,
			PrefabFactory prefabFactory)
		{
			_popupStructurePrefab = popupStructurePrefab;
			_prefabFactory = prefabFactory;
		}

		protected virtual void Start()
		{
			Structure = _prefabFactory.Create(_popupStructurePrefab);
			Structure.Base.SetParent(Hook, false);
		}
	}
}