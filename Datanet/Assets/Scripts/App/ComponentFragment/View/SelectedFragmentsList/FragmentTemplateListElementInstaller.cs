using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateListElementInstaller : MonoInstaller
	{
		[Inject]
		private ComponentFragmentTemplate _fragmentTemplate = null;
		[Inject]
		private FragmentInfosRepository _repository = null;

		public override void InstallBindings()
		{
			Container.Bind(typeof(ComponentFragmentTemplate)).
				To<ComponentFragmentTemplate>().FromInstance(_fragmentTemplate).AsSingle();
			Container.Bind(typeof(FragmentInfo)).To<FragmentInfo>().
				FromInstance(_repository.Get().Get(_fragmentTemplate.Type)).AsSingle();
		}
	}
}