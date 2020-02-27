using System;

namespace SBaier.Datanet.Core
{
	public abstract class NodeComponent
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


		public NodeComponent(Guid iD)
		{
			ID = iD;
			Name = "New Component";
		}
	}
}