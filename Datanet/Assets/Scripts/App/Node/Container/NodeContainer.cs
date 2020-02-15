

using System;

namespace SBaier.Datanet.Core
{
	public abstract class NodeContainer
	{
		public abstract int Count { get; }
		public abstract void AddNode(Node node);

		public abstract void RemoveNode(Guid nodeID);

		public abstract Node GetNode(Guid nodeID);
	}
}