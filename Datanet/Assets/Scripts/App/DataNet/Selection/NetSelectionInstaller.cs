using SBaier.Datanet;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionInstaller : MonoInstaller
	{

		public override void InstallBindings()
		{
			DataNetCreationInstaller.Install(Container);
		}
	}
}