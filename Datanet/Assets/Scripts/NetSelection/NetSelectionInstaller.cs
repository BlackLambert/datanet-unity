using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionInstaller : MonoInstaller
	{
		[SerializeField]
		private NetSelectionElementInstaller _netSelectionElementPrefab;

		public override void InstallBindings()
		{
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<DataNetCreationData>().To<DataNetCreationData>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidator>().AsSingle();
			Container.Bind<PrefabFactory>().To<PrefabFactory>().AsSingle();
			Container.Bind<NetSelectionElementInstaller>().To<NetSelectionElementInstaller>().FromInstance(_netSelectionElementPrefab).AsSingle();
		}
	}
}