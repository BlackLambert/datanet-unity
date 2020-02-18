using SBaier.Datanet.Core;
using SBaier.Popup;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetWorkspaceInstaller : MonoInstaller
	{
		[Inject]
		private SelectedDataNet _selectedDataNet= null;

		public override void InstallBindings()
		{
			Container.Bind<DataNet>().FromInstance(_selectedDataNet.Selected).AsSingle();
			Container.Bind<PopupFactory>().To<PopupFactoryImpl>().AsSingle();
			Container.Bind<PrefabFactory>().AsSingle();
		}
	}
}