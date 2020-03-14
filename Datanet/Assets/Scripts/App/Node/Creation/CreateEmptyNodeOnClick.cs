using System;
using SBaier.Datanet.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class CreateEmptyNodeOnClick : NodeCreator
	{
		[SerializeField]
		private Button _button = null;

		public override event Action<Node> OnNodeCreated;

		private NodeFactory _nodeFactory = null;
		private NodesRepository _nodesRepository = null;
		private DataNet _dataNet = null;


		[Inject]
		private void Construct(NodeFactory nodeFactory,
			NodesRepository nodesRepository,
			DataNet dataNet)
		{
			_nodeFactory = nodeFactory;
			_nodesRepository = nodesRepository;
			_dataNet = dataNet;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			createNode();
		}

		private void createNode()
		{
			Node result = _nodeFactory.Create(new NodeFactory.Parameter());
			_nodesRepository.Add(result);
			_dataNet.AddNode(result);
			OnNodeCreated?.Invoke(result);
		}
	}
}