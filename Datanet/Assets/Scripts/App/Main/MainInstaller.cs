using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;
using SBaier.Storage;
using System;
using System.Collections.Generic;
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
		}
	}
}