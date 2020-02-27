using SBaier.Datanet.Core;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionInstaller : MonoInstaller
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