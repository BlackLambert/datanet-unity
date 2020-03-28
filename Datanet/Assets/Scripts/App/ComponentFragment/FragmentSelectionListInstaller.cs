using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentSelectionListInstaller : MonoInstaller
	{
		[SerializeField]
		private string _listElementPrefabPath = "Prefabs/ComponentTemplateCreation/TextFragmentTempalteListElement";

		[Inject]
		private NodeComponentTemplate _componentTempalte = null;

		public override void InstallBindings()
		{
			Container.Bind((typeof(PrefabFactory))).To<PrefabFactory>().AsTransient();
			Container.Bind((typeof(NodeComponentTemplate))).To<NodeComponentTemplate>().FromInstance(_componentTempalte).AsSingle();
			Container.Bind((typeof(FragmentSelectionListElementInstaller))).FromResource(_listElementPrefabPath).AsSingle();
		}
	}
}