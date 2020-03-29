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

		[JsonProperty]
		public ComponentFragmentType Type
		{
			get;
			private set;
		}

		public ComponentFragmentTemplate(Guid iD,
			ComponentFragmentType type)
		{
			ID = iD;
			Type = type;
		}
	}
}