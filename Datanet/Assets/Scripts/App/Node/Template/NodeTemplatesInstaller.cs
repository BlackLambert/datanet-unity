using SBaier.Datanet;
using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeTemplatesInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "NodeTemplates.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(Repository<NodeTemplates>),
				typeof(NodeTemplatesRepository)).To<NodeTemplatesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<NodeTemplates>)).To<NodeTemplatesSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<NodeTemplates>)).To<NodeTemplatesLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<NodeTemplates>)).To<NodeTemplatesPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}