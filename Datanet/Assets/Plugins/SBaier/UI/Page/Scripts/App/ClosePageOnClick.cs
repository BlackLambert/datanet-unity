using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI.Page
{
	public class ClosePageOnClick : CloseViewOnClick<Page>
	{
		private PageInstaller _pageInstaller;

		protected override Page ViewToClose => _pageInstaller.Page;

		protected override Transform ViewToCloseBase => _pageInstaller.Base;

		[Inject]
		private void Construct(PageInstaller pageInstaller)
		{
			_pageInstaller = pageInstaller;
		}

		
	}
}