

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public abstract class NodeContainer
	{
		public abstract IEnumerable<Node> IDToNodeCopy { get; } 
		public abstract int Count { get; }
		public abstract void AddNode(Node node);

		public abstract void RemoveNode(Guid nodeID);

		public abstract Node GetNode(Guid nodeID);
		public abstract event Action<Node> OnNodeAdded;
		public abstract event Action<Node> OnNodeRemoved;
	}
}