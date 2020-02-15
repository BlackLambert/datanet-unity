using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

public class NetSelectionElementInstaller : MonoInstaller
{
	[Inject]
	private DataNet _dataNet = null;

    public override void InstallBindings()
    {
		Container.Bind<DataNet>().To<DataNet>().FromInstance(_dataNet).AsSingle();
    }
}