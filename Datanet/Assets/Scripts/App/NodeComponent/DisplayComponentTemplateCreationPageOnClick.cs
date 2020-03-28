using SBaier.UI.Page;
using Zenject;

namespace SBaier.Datanet
{
	public class DisplayComponentTemplateCreationPageOnClick : DisplayPageOnClick
	{
		private PageFromResourceLoader _pageLoader;
		private NodeComponentTemplateFactory _templateFactory;

		[Inject]
		private void Construct(PageFromResourceLoader pageLoader,
			NodeComponentTemplateFactory templateFactory)
		{
			_pageLoader = pageLoader;
			_templateFactory = templateFactory;
		}


		protected override Page loadView()
		{
			NodeComponentTemplate template = _templateFactory.Create();
			PrefabFactory.Parameter[] parameters = new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(template) };
			return _pageLoader.Load(ResourcePaths.ComponentTemplateCreationPage, parameters);
		}
	}
}