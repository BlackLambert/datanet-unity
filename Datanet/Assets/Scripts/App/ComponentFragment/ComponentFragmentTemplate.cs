using System;

namespace SBaier.Datanet.Core
{
	[Serializable]
	public class ComponentFragmentTemplate
	{
		public Guid ID
		{
			get;
			private set;
		}

		public ComponentFragmentTemplate(Guid iD)
		{
			ID = iD;
		}
	}
}