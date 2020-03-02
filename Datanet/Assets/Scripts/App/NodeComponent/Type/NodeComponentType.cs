using System;

namespace SBaier.Datanet.Core
{
	public class NodeComponentType 
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

		public NodeComponentType(Guid id, string name)
		{
			ID = id;
			Name = name;
		}
	}
}