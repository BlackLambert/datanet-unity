using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentSelectionListElementInstaller : MonoInstaller
	{
		[Inject]
		private FragmentInfo _info = null;

		public override void InstallBindings()
		{
			Container.Bind(typeof(FragmentInfo)).FromInstance(_info).AsSingle();
		}
	}
}