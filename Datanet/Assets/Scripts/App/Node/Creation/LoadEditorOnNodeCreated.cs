using SBaier.Datanet.Core;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class LoadEditorOnNodeCreated : MonoBehaviour
	{
		[SerializeField]
		private NodeCreator _creator = null;

		private NodeEditorLoader _nodeEditorLoader = null;

		[Inject]
		private void Construct(NodeEditorLoader nodeEditorLoader)
		{
			_nodeEditorLoader = nodeEditorLoader;
		}

		protected virtual void Start()
		{
			_creator.OnNodeCreated += onNodeCreated;
		}

		protected virtual void OnDestroy()
		{
			_creator.OnNodeCreated -= onNodeCreated;
		}

		private void onNodeCreated(Node node)
		{
			_nodeEditorLoader.LoadEditorFor(node.ID); 
		}

	}
}