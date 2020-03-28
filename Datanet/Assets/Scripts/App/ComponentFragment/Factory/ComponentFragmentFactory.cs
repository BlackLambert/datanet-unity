using System;

namespace SBaier.Datanet
{
	public abstract class ComponentFragmentFactory 
	{
		public abstract ComponentFragment CreateByTemplate(Guid templateID);
		public abstract ComponentFragment CreateByData(Guid dataID);
	}
}