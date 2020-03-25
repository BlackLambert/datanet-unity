using SBaier.Datanet.Core;
using SBaier.Persistence;
using SBaier.Serialization.String;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetsInstaller : MonoInstaller<DataNetsInstaller>
	{
		[SerializeField]
		private string _persistencePath = "Data/DataNets.json";
		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(DataNetsRepository), typeof(Repository<DataNets>)).
				To<DataNetsRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<DataNets>)).To<DataNetsSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<DataNets>)).To<DataNetsLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<DataNets>)).To<DataNetsPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}