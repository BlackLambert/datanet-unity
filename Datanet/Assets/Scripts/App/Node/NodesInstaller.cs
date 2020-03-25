using SBaier.Datanet.Core;
using SBaier.Persistence;
using SBaier.Serialization.String;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodesInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "Nodes.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(NodesRepository), typeof(Repository<Nodes>)).
				To<NodesRepository>().AsSingle();
			Container.Bind(typeof(DataSaver<Nodes>)).To<NodesSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<Nodes>)).To<NodesLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<Nodes>)).To<NodesPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}