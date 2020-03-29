using UnityEngine;
using Zenject;

namespace SBaier.UI.Page
{
	public class PageInstaller : MonoInstaller
	{
		[SerializeField]
		private Page _page = null;
		public Page Page { get { return _page; } }

		public override void InstallBindings()
		{
			Container.Bind<Page>().FromInstance(Page).AsSingle();
			Container.Bind(typeof(PageDestructor), typeof(ViewDestructor<Page>)).To<PageDestructor>().AsTransient();
		}
	}
}