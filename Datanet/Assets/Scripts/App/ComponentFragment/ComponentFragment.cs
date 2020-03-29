using System;

namespace SBaier.Datanet
{
	public abstract class ComponentFragment
	{
		public abstract Guid ID { get; }
		public abstract string Name { get; }

		public ComponentFragment()
		{

		}
	}
}