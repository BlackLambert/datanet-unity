using SBaier.Persistence;
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
		private string _fileName = "NodeDatas.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(NodesRepository), typeof(Repository<Nodes>)).
				To<NodesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(NodeProvider)).AsTransient();

			Container.Bind(typeof(NodeDatasRepository), typeof(Repository<NodeDatas>)).
				To<NodeDatasRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<NodeDatas>)).To<NodeDatasSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<NodeDatas>)).To<NodeDatasLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<NodeDatas>)).To<NodeDatasPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}