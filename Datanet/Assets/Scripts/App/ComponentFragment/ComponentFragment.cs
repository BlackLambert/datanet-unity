using System;

namespace SBaier.Datanet.Core
{
	public class ComponentFragment
	{
		public Guid ID
		{
			get;
			private set;
		}

		public ComponentFragment(Guid iD)
		{
			ID = iD;
		}
	}
}