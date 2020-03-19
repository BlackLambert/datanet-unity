using SBaier.Datanet.Core;
using System;
using SBaier.UI.Page;

namespace SBaier.Datanet
{
	public class NodeEditorLoader
	{
		private NodesRepository _nodesRepository = null;
		private PrefabFactory _prefabFactory = null;
		private PageViewDisplayer _pageDisplayer = null;
		private Page _editorPagePrefab;

		public NodeEditorLoader(NodesRepository nodesRepository,
			PrefabFactory prefabFactory,
			PageViewDisplayer pageDisplayer,
			Page editorPagePrefab)
		{
			_nodesRepository = nodesRepository;
			_prefabFactory = prefabFactory;
			_pageDisplayer = pageDisplayer;
			_editorPagePrefab = editorPagePrefab;
		}

		public void LoadEditorFor(Guid nodeID)
		{
			Node node = _nodesRepository.Get().Get(nodeID);
			PrefabFactory.Parameter[] parameters = new PrefabFactory.Parameter[]
			{
				new PrefabFactory.Parameter(node)
			};
			Page editorPage = _prefabFactory.Create(_editorPagePrefab, parameters);
			_pageDisplayer.Display(editorPage);
		}
	}
}