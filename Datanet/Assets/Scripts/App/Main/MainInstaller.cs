using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;
using SBaier.Storage;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class MainInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind(typeof(DataNetsRepository), typeof(ICollectionRepository<KeyValuePair<Guid, DataNet>>)).
				To<DataNetsRepositoryImpl>().AsSingle();
			Container.Bind(typeof(NodesRepository), typeof(ICollectionRepository<KeyValuePair<Guid, Node>>)).
				To<NodesRepositoryImp>().AsSingle();
			Container.Bind<SelectedDataNet>().To<SelectedDataNet>().AsSingle();
		}
	}
}