using Zenject;
using SBaier.Persistence;
using SBaier.Serialization.String;
using SBaier.UI.Page;
using SBaier.LocalDataAccess;

namespace SBaier.Datanet
{
	public class MainInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind(typeof(DataSaver), typeof(CollectiveDataSaver)).To<CollectiveDataSaver>().AsSingle();
			Container.Bind<SelectedDataNet>().To<SelectedDataNet>().AsSingle();
			Container.Bind(typeof(StringSerializer)).To<JsonDotNetSerializer>().AsTransient();
			bindLocalDataAccesser();
		}

		private void bindLocalDataAccesser()
		{
#if UNITY_ANDROID
			Container.Bind(typeof(LocalDataAccesser)).To<AndroidDataAccesser>().AsTransient();
#else
			Container.Bind(typeof(LocalDataAccesser)).To<DefaultDataAccesser>().AsTransient();
#endif
		}
	}
}