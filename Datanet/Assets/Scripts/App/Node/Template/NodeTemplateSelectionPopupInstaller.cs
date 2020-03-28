using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeTemplateSelectionPopupInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind(typeof(SelectNodeTemplateElementInstaller)).FromResource(ResourcePaths.NodeTemplateSelectionElement).AsSingle();
		}
	}
}