using SBaier.Datanet.Core;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectedMainInstaller : MonoInstaller<NetSelectedMainInstaller>
	{
		public static readonly string NetName = "My Net";

		public override void InstallBindings()
		{
			DataNetCreationInstaller.Install(Container);
			DataNetFactory netFactory = Container.Resolve<DataNetFactory>();
			SelectedDataNet selectedDataNet = Container.Resolve<SelectedDataNet>();
			
			DataNetsRepository dataNetsRepository = Container.Resolve<DataNetsRepository>();
			dataNetsRepository.Store(new DataNets());
			DataNet net = netFactory.Create(new DataNetFactory.Parameter(NetName));
			selectedDataNet.Selected = net;
			dataNetsRepository.Get().Add(net);
		}
	}
}