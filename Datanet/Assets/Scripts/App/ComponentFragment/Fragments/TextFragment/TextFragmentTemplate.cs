using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TextFragmentTemplate : ComponentFragmentTemplate
	{
		[JsonProperty]
		public string DefaultValue { get; private set; }
		[JsonProperty]
		public bool Editable { get; private set; }

		public TextFragmentTemplate(Guid iD, string defaultValue, bool editable) : base(iD)
		{
			DefaultValue = defaultValue;
			Editable = editable;
		}
	}
}