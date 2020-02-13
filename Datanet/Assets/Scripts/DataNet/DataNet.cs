

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

		public string Name
		{
			get;
			set;
		}


		public DataNet(Guid iD, 
			NodeContainer nodeContainer,
			string name)
		{
			ID = iD;
			NodeContainer = nodeContainer;
			Name = name;
		}
	}
}