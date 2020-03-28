using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodesListInstaller : MonoInstaller
	{
		[SerializeField]
		private string _nodesListElementsPrefabPath = "Prefabs/NetWorkspace/NodesList/NodesListElement";


		public override void InstallBindings()
		{
			Container.Bind(typeof(NodesListElementInstaller)).FromResource(_nodesListElementsPrefabPath).AsSingle();
		}
	}
}