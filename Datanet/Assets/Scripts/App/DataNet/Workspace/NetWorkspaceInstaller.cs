using SBaier.Datanet.Core;
using SBaier.UI.Popup;
using SBaier.Storage;
using System;
using System.Collections.Generic;
using Zenject;
using SBaier.UI.Page;
using UnityEngine;

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
			Container.Bind<PopupViewDisplayer>().To<DataNetPopupViewDisplayer>().AsSingle();
			Container.Bind(typeof(ICollectionRepository<KeyValuePair<Guid, NodeTemplate>>),
				typeof(NodeTemplatesRepository)).To<NodeTemplatesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(PageViewDisplayer)).To<WorkspacePageViewDisplayer>().AsSingle();
			Container.Bind<OnStartPageLoader>().FromNewComponentOnNewGameObject().AsSingle().
				WithArguments(ResourcePaths.NetDashboard_NetDashboard).NonLazy();
			Page editorPage = Resources.Load<GameObject>(ResourcePaths.NodeEditorPage).GetComponentInChildren<Page>();
			Container.Bind<NodeEditorLoader>().AsTransient().WithArguments(editorPage);
			Container.Bind<NodeFactory>().To<NodeFactoryImpl>().AsTransient();
		}
	}
}