using System;

namespace SBaier.Datanet.Core
{
	public class NodeType
	{
		public Guid ID
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			set;
		}

		public NodeType(Guid iD, string name)
		{
			ID = iD;
			Name = name;
		}
	}
}