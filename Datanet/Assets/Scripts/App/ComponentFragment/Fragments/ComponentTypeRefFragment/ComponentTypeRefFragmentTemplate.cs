using System;

namespace SBaier.Datanet.Core
{
	public class ComponentTypeRefFragmentTemplate : ComponentFragmentTemplate
	{
		public Guid ComponentTypeID
		{
			get;
			private set;
		}

		public ComponentTypeRefFragmentTemplate(Guid iD, Guid componentTypeID) : base(iD)
		{
			ComponentTypeID = componentTypeID;
		}
	}
}