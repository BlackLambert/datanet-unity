using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ComponentFragmentTemplate
	{
		[JsonProperty]
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