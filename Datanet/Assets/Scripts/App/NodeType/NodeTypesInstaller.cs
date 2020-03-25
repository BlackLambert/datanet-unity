using SBaier.Datanet.Core;
using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeTypesInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "NodeTypes.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(NodeTypesRepository), typeof(Repository<NodeTypes>)).
				To<NodeTypesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<NodeTypes>)).To<NodeTypesSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<NodeTypes>)).To<NodeTypesLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<NodeTypes>)).To<NodeTypesPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}