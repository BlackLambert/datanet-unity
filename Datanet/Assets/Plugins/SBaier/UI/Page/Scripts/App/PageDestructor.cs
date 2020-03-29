
using Zenject;

namespace SBaier.UI.Page
{
	public class PageDestructor : ViewDestructor<Page>
	{
		private Page _page;

		[Inject]
		private void Construct(Page page)
		{
			_page = page;
		}


		protected override Page ViewToClose => _page;
	}
}