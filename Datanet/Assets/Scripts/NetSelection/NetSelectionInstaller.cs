using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<DataNetFactory>().To<DataNetFactoryImpl>().AsSingle();
		}
	}
}