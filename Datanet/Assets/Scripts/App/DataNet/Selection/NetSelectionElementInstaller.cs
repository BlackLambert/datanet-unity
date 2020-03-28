using SBaier.Datanet;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionElementInstaller : MonoInstaller
	{
		[Inject]
		private DataNet _dataNet = null;

		public override void InstallBindings()
		{
			Container.Bind<DataNet>().To<DataNet>().FromInstance(_dataNet).AsSingle();
		}
	}
}