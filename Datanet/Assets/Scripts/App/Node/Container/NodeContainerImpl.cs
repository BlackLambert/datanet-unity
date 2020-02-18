

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class NodeContainerImpl : NodeContainer
	{
		private Dictionary<Guid, Node> _iDToNode;
		public override IEnumerable<Node> IDToNodeCopy => new List<Node>(_iDToNode.Values);
		public override event Action<Node> OnNodeAdded;
		public override event Action<Node> OnNodeRemoved;

		public override int Count => _iDToNode.Count;

		public NodeContainerImpl()
		{
			_iDToNode = new Dictionary<Guid, Node>();
		}


		public override void AddNode(Node node)
		{
			_iDToNode.Add(node.ID, node);
			OnNodeAdded?.Invoke(node);
		}

		public override void RemoveNode(Guid nodeID)
		{
			Node removedNode = _iDToNode[nodeID];
			_iDToNode.Remove(nodeID);
			OnNodeRemoved?.Invoke(removedNode);
		}

		public override Node GetNode(Guid nodeID)
		{
			return _iDToNode[nodeID];
		}
	}
}