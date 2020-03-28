using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class TextFragmentTemplateListElementInstaller : MonoInstaller
	{
		[Inject]
		private TextFragmentTemplate _textFragmentTemplate = null;

		public override void InstallBindings()
		{
			Container.Bind(typeof(TextFragmentTemplate), typeof(ComponentFragmentTemplate)).
				To<TextFragmentTemplate>().FromInstance(_textFragmentTemplate).AsSingle();
		}
	}
}