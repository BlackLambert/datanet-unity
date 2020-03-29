using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateListElementInstaller : MonoInstaller
	{
		[Inject]
		private ComponentFragmentTemplate _fragmentTemplate = null;

		public override void InstallBindings()
		{
			Container.Bind(typeof(ComponentFragmentTemplate)).
				To<ComponentFragmentTemplate>().FromInstance(_fragmentTemplate).AsSingle();
		}
	}
}