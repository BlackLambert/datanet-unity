using SBaier.Datanet.Core;

namespace SBaier.Datanet
{
	public class NetSelectedMainInstaller : MainInstaller
	{
		public static readonly string NetName = "My Net";

		public override void InstallBindings()
		{
			base.InstallBindings();
			DataNetCreationInstaller.Install(Container);
			DataNetFactory netFactory = Container.Resolve<DataNetFactory>();
			SelectedDataNet selectedDataNet = Container.Resolve<SelectedDataNet>();
			DataNetsRepository dataNetsRepository = Container.Resolve<DataNetsRepository>();
			DataNet net = netFactory.Create(new DataNetFactory.Parameter(NetName));
			selectedDataNet.Selected = net;
			dataNetsRepository.Add(net);
		}
	}
}