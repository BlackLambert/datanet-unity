

using System;

namespace SBaier.Datanet.Core
{
	public class NodeReferenceComponent : NodeComponent
	{
		public Guid ReferencedNodeID
		{
			get;
			set;
		}

		public NodeReferenceComponent(Guid iD,
			Guid referencedNodeID) : base(iD)
		{
			ReferencedNodeID = referencedNodeID;
		}
	}
}