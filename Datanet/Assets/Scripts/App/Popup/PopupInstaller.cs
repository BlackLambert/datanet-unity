using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform _base = null;
		public Transform Base { get{ return _base; }  }

		[Inject]
		private PopupStructure _popupStructurePrefab = null;
		[Inject]
		private PopupContent _popupContentPrefab = null;

		public override void InstallBindings()
		{
			Container.Bind<PrefabFactory>().AsSingle();
			Container.Bind<PopupInstaller>().FromInstance(this).AsSingle();
			Container.Bind<PopupStructure>().FromInstance(_popupStructurePrefab).AsSingle();
			Container.Bind<PopupContent>().FromInstance(_popupContentPrefab).AsSingle();
		}
	}
}