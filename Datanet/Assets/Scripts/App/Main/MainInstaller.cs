using SBaier.Datanet.Core;
using Zenject;
using SBaier.Storage;
using SBaier.Persistence;

namespace SBaier.Datanet
{
	public class MainInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind(typeof(DataSaver), typeof(CollectiveDataSaver)).To<CollectiveDataSaver>().AsSingle();
			Container.Bind(typeof(NodesRepository), typeof(Repository<Nodes>)).
				To<NodesRepository>().AsSingle();
			Container.Bind<SelectedDataNet>().To<SelectedDataNet>().AsSingle();
			bindLocalDataAccesser();
		}

		private void bindLocalDataAccesser()
		{
#if UNITY_ANDROID
			Container.Bind(typeof(AndroidDataAccesser)).To<LocalDataAccesser>().AsTransient();
#else
			Container.Bind(typeof(DefaultDataAccesser)).To<LocalDataAccesser>().AsTransient();
#endif
		}
	}
}