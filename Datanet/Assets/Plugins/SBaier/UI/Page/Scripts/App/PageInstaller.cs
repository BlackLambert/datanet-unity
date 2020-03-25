using UnityEngine;
using Zenject;

namespace SBaier.UI.Page
{
	public class PageInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform _base = null;
		public Transform Base { get{ return _base; }  }
		[SerializeField]
		private Page _page = null;
		public Page Page { get { return _page; } }

		public override void InstallBindings()
		{
			Container.Bind<PageInstaller>().FromInstance(this).AsSingle();
		}
	}
}