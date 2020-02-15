

using System;
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

		public override void AddNode(Node node)
		{
			Debug.Log("Successfuly added node to dummy container");
		}

		public override Node GetNode(Guid nodeID)
		{
			Debug.Log("Dummy Container returns dummy Node");
			return _dummyNode;
		}

		public override void RemoveNode(Guid nodeID)
		{
			Debug.Log("Successfuly removed node from dummy container");
		}
	}
}