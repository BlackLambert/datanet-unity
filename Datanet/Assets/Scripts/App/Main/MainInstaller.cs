using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class MainInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<DataNetContainer>().To<DataNetContainer>().AsSingle();
			Container.Bind<PrefabFactory>().To<PrefabFactory>().AsSingle();
			Container.Bind<SelectedDataNet>().To<SelectedDataNet>().AsSingle();
		}
	}
}