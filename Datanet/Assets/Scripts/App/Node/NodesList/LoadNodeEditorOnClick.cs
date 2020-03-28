using SBaier.Datanet;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class LoadNodeEditorOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;

		private NodeEditorLoader _nodeEditorLoader = null;
		private Node _node;

		protected virtual void Start()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(onClick);
		}

		[Inject]
		private void Construct(NodeEditorLoader nodeEditorLoader, Node node)
		{
			_nodeEditorLoader = nodeEditorLoader;
			_node = node;
		}

		private void onClick()
		{
			_nodeEditorLoader.LoadEditorFor(_node.ID);
		}
	}
}