using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ComponentFragmentData
	{
		[JsonProperty]
		public Guid ID { get; }
		[JsonProperty]
		public Guid TemplateID { get; }

		public ComponentFragmentData(Guid iD,
			Guid templateID)
		{
			ID = iD;
		}
	}
}