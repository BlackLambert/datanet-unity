using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeComponentTemplatesInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "NodeComponentTemplates.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(NodeComponentTemplatesRepository), typeof(Repository<NodeComponentTemplates>)).
				To<NodeComponentTemplatesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(NodeComponentTemplateFactory)).To<NodeComponentTemplateFactoryImpl>().AsTransient();
			Container.Bind(typeof(DataSaver<NodeComponentTemplates>)).To<NodeComponentTemplatesSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<NodeComponentTemplates>)).To<NodeComponentTemplatesLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<NodeComponentTemplates>)).To<NodeComponentTemplatesPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}