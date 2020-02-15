

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class NodeContainerImpl : NodeContainer
	{
		private Dictionary<Guid, Node> _iDToNode;

		public override int Count => _iDToNode.Count;

		public NodeContainerImpl()
		{
			_iDToNode = new Dictionary<Guid, Node>();
		}


		public override void AddNode(Node node)
		{
			throw new NotImplementedException();
		}

		public override void RemoveNode(Guid nodeID)
		{
			throw new NotImplementedException();
		}

		public override Node GetNode(Guid nodeID)
		{
			throw new NotImplementedException();
		}
	}
}