using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeComponentDatasInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "NodeComponentDatas.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(NodeComponentsRepository), typeof(Repository<NodeComponents>)).
				To<NodeComponentsRepositoryImpl>().AsSingle();
			Container.Bind(typeof(NodeComponentProvider)).AsTransient();

			Container.Bind(typeof(NodeComponentDatasRepository), typeof(Repository<NodeComponentDatas>)).
				To<NodeComponentDatasRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<NodeComponentDatas>)).To<NodeComponentDatasSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<NodeComponentDatas>)).To<NodeComponentDatasLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<NodeComponentDatas>)).To<NodeComponentDatasPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}