using SBaier.Persistence;
using SBaier.Storage;
using System.IO;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentFragmentTemplatesInstaller : MonoInstaller
	{
		[SerializeField]
		private string _persistencePath = "Data/Nets";
		[SerializeField]
		private string _fileName = "ComponentFragmentTemplates.json";

		[Inject]
		private DataNet _dataNet = null;

		public string PersistencePath { get { return Path.Combine(Application.persistentDataPath, _persistencePath, _dataNet.ID.ToString(), _fileName); } }

		public override void InstallBindings()
		{
			Container.Bind(typeof(ComponentFragmentTemplatesRepository), typeof(Repository<ComponentFragmentTemplates>)).
				To<ComponentFragmentTemplatesRepositoryImpl>().AsSingle();
			Container.Bind(typeof(ComponentFragmentTemplateFactory)).To<ComponentFragmentTemplateFactoryImpl>().AsTransient();
			Container.Bind(typeof(FragmentTemplateDestructor)).To<FragmentTemplateDestructorImpl>().AsTransient();
			Container.Bind(typeof(DataSaver<ComponentFragmentTemplates>)).To<ComponentFragmentTemplatesSaver>().AsTransient();
			Container.Bind(typeof(DataLoader<ComponentFragmentTemplates>)).To<ComponentFragmentTemplatesLoader>().AsTransient();
			Container.Bind(typeof(DataPreserver<ComponentFragmentTemplates>)).To<ComponentFragmentTemplatesPreserver>().AsTransient().WithArguments(PersistencePath);
		}
	}
}