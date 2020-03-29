using SBaier.Storage;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateListInstaller : MonoInstaller
	{
		[SerializeField]
		private string _listElementPrefabPath = "Prefabs/ComponentTemplateCreation/FragmentTemplateListElement";

		[Inject]
		private NodeComponentTemplate _template = null;
		private FragmentTemplatesOfComponent _fragmentTemplatesOfComponent;


		public override void InstallBindings()
		{
			Container.Bind(typeof(FragmentTemplatesOfComponentRepository), typeof(Repository<FragmentTemplatesOfComponent>)).
				FromInstance(createFragmentTemplatesOfComponentRepository()).AsSingle();
			Container.Bind((typeof(PrefabFactory))).To<PrefabFactory>().AsTransient();
			Container.Bind((typeof(NodeComponentTemplate))).To<NodeComponentTemplate>().FromInstance(_template).AsSingle();
			Container.Bind((typeof(FragmentTemplateListElementInstaller))).FromResource(_listElementPrefabPath).AsSingle();
		}

		private FragmentTemplatesOfComponentRepository createFragmentTemplatesOfComponentRepository()
		{
			FragmentTemplatesOfComponentRepository result = new FragmentTemplatesOfComponentRepository();
			_fragmentTemplatesOfComponent = new FragmentTemplatesOfComponent(_template);
			result.Store(_fragmentTemplatesOfComponent);
			return result;
		}

		protected virtual void OnDestroy()
		{
			_fragmentTemplatesOfComponent.Dispose();
		}
	}
}