using SBaier.Datanet;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodesListElementInstaller : MonoInstaller
	{
		[Inject]
		private Node _node = null;

		public override void InstallBindings()
		{
			Container.Bind<Node>().FromInstance(_node).AsSingle();
		}
	}
}