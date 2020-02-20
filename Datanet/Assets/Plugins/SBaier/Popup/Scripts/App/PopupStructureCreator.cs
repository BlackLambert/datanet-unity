using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupStructureCreator : MonoBehaviour
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

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
			PopupStructure structure = _prefabFactory.Create(_popupStructurePrefab);
			structure.Base.SetParent(Hook, false);
		}
	}
}