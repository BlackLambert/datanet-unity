using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class SelectNodeTemplateElementInstaller : MonoInstaller
	{
		[Inject]
		private NodeTemplate _template = null;

		public override void InstallBindings()
		{
			Container.Bind<NodeTemplate>().FromInstance(_template).AsSingle();
		}
	}
}