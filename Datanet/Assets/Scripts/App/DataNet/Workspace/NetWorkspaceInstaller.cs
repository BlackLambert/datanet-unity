using SBaier.Datanet;
using SBaier.UI.Popup;
using SBaier.Storage;
using Zenject;
using SBaier.UI.Page;
using UnityEngine;
using SBaier.UI;

namespace SBaier.Datanet
{
	public class NetWorkspaceInstaller : MonoInstaller
	{
		[Inject]
		private SelectedDataNet _selectedDataNet= null;

		public override void InstallBindings()
		{
			Container.Bind<DataNet>().FromInstance(_selectedDataNet.Selected).AsSingle();
			Container.Bind<PopupFactory>().To<PopupFactoryImpl>().AsTransient();
			Container.Bind<PrefabFactory>().AsTransient();
			Container.Bind<PopupResourcePaths>().To<DataNetPopupResourcePaths>().AsTransient();
			Container.Bind(typeof(PopupViewDisplayer), typeof(ViewDisplayer<Popup>)).To<DataNetPopupViewDisplayer>().AsSingle();
			Container.Bind(typeof(PageViewDisplayer), typeof(ViewDisplayer<Page>)).To<WorkspacePageViewDisplayer>().AsSingle();
			Container.Bind<OnStartPageLoader>().FromNewComponentOnNewGameObject().AsSingle().
				WithArguments(ResourcePaths.NetDashboard_NetDashboard).NonLazy();
			Page editorPage = Resources.Load<GameObject>(ResourcePaths.NodeEditorPage).GetComponentInChildren<Page>();
			Container.Bind<NodeEditorLoader>().AsTransient().WithArguments(editorPage);
			Container.Bind<NodeFactory>().To<NodeFactoryImpl>().AsTransient();
			Container.Bind(typeof(PageFromResourceLoader)).AsTransient();
		}
	}
}