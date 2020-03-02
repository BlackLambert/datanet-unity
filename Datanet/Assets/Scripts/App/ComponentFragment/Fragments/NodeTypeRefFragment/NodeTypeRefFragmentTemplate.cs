using System;

namespace SBaier.Datanet.Core
{
	public class NodeTypeRefFragmentTemplate : ComponentFragmentTemplate
	{
		public Guid NodeTypeID
		{
			get;
			private set;
		}

		public NodeTypeRefFragmentTemplate(Guid iD, Guid nodeTypeID) : base(iD)
		{
			NodeTypeID = nodeTypeID;
		}
	}
}