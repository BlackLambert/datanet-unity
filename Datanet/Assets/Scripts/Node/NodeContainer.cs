

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class NodeContainer
	{
		private Dictionary<Guid, Node> _iDToNode;


		public NodeContainer()
		{
			_iDToNode = new Dictionary<Guid, Node>();
		}


		public void AddNode(Node node)
		{
			throw new NotImplementedException();
		}

		public void RemoveNode(Guid nodeID)
		{
			throw new NotImplementedException();
		}

		public Node GetNode(Guid nodeID)
		{
			throw new NotImplementedException();
		}
	}
}