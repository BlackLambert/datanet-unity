using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentFragmentDatasInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "ComponentFragmentDatas.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(ComponentFragmentDatasRepository), typeof(Repository<ComponentFragmentDatas>)).
				To<ComponentFragmentDatasRepositoryImpl>().AsSingle();
			Container.Bind(typeof(DataSaver<ComponentFragmentDatas>)).To<ComponentFragmentDatasSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<ComponentFragmentDatas>)).To<ComponentFragmentDatasLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<ComponentFragmentDatas>)).To<ComponentFragmentDatasPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}