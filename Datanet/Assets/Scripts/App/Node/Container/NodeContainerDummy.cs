

using System;
using System.Collections.Generic;
using SBaier.Datanet.Core;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public class NodeContainerDummy : NodeContainer
	{
		private Node _dummyNode;

		public NodeContainerDummy()
		{
			_dummyNode = new Node(Guid.NewGuid(), Guid.NewGuid());
		}

		public override int Count => 0;

		public override IEnumerable<Node> IDToNodeCopy => new List<Node>();
		public override event Action<Node> OnNodeAdded;
		public override event Action<Node> OnNodeRemoved;

		public override void AddNode(Node node)
		{
			Debug.Log("Successfuly added node to dummy container");
			OnNodeAdded.Invoke(node);
		}

		public override Node GetNode(Guid nodeID)
		{
			Debug.Log("Dummy Container returns dummy Node");
			return _dummyNode;
		}

		public override void RemoveNode(Guid nodeID)
		{
			Debug.Log("Successfuly removed node from dummy container");
			OnNodeRemoved.Invoke(new NodeFactoryDummy().Create(new NodeFactory.Parameter(nodeID, Guid.Empty)));
		}
	}
}