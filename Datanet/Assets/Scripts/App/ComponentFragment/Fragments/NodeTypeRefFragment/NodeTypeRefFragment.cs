using System;

namespace SBaier.Datanet.Core
{
	public class NodeTypeRefFragment : ComponentFragment
	{
		public Guid NodeTypeID
		{
			get;
			set;
		}


		public NodeTypeRefFragment(Guid iD, Guid nodeTypeID) : base(iD)
		{
			NodeTypeID = nodeTypeID;
		}
	}
}