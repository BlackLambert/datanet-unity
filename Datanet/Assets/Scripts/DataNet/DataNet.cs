

using System;

namespace SBaier.Datanet.Core
{
	public class DataNet
	{
		public Guid ID
		{
			get;
			private set;
		}

		public NodeContainer NodeContainer
		{
			get;
			private set;
		}


		public DataNet(Guid iD, NodeContainer nodeContainer)
		{
			ID = iD;
			NodeContainer = nodeContainer;
		}
	}
}