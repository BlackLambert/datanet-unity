using SBaier.UI.Page;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentTemplateCreationPageInstaller : PageInstaller
	{
		public override void InstallBindings()
		{
			base.InstallBindings();
			Container.Bind(typeof(ComponentTemplateCreationData)).AsSingle();
		}
	}
}