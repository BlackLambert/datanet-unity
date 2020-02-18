using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ExistingNetOverviewInstaller : MonoInstaller
	{

		public override void InstallBindings()
		{
			Container.Bind<NetSelectionElementInstaller>().FromResource(ResourcePaths.NetSelectionElement).AsSingle();
		}
	}
}