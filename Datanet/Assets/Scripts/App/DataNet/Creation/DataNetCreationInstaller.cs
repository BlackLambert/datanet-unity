using UnityEngine;
using Zenject;
using SBaier.Datanet.Core;

namespace SBaier.Datanet
{
	public class DataNetCreationInstaller : Installer<DataNetCreationInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
			Container.Bind<DataNetCreationData>().To<DataNetCreationData>().AsSingle();
			Container.Bind<DataNetNameValidator>().To<DataNetNameValidatorImpl>().AsSingle();
			Container.Bind<PrefabFactory>().To<PrefabFactory>().AsSingle();
		}
	}
}