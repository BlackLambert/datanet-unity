using SBaier.Datanet.Core;
using SBaier.Popup;
using SBaier.Storage;
using System;
using System.Collections.Generic;
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
			Container.Bind<PopupFactory>().To<PopupFactoryImpl>().AsTransient();
			Container.Bind<PrefabFactory>().AsTransient();
			Container.Bind<PopupResourcePaths>().To<DataNetPopupResourcePaths>().AsTransient();
			NodeTemplatesRepositoryImpl rep = new NodeTemplatesRepositoryImpl();
			NodeTemplate template = new NodeTemplate(Guid.NewGuid(), "My Tempalte", new List<NodeComponentTemplate>());
			rep.Add(template.ID, template);
			Container.Bind(typeof(NodeTemplatesRepository), typeof(ICollectionRepository<KeyValuePair<Guid, NodeTemplate>>)).
				To<NodeTemplatesRepositoryImpl>().FromInstance(rep).AsSingle();
		}
	}
}