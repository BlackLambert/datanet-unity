using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform _base = null;
		public Transform Base { get{ return _base; }  }

		[InjectOptional]
		private PopupStructure _popupStructurePrefab = null;
		public PopupStructure PopupStructurePrefab { get { return _popupStructurePrefab; } }
		[InjectOptional]
		private PopupContent _popupContentPrefab = null;
		public PopupContent PopupContentPrefab { get { return _popupContentPrefab; } }

		public override void InstallBindings()
		{
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<PopupInstaller>().FromInstance(this).AsSingle();
			if(_popupStructurePrefab != null)
				Container.Bind<PopupStructure>().FromInstance(_popupStructurePrefab).AsSingle();
			if (_popupContentPrefab != null)
				Container.Bind<PopupContent>().FromInstance(_popupContentPrefab).AsSingle();
		}
	}
}