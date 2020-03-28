using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TextFragmentData : ComponentFragmentData
	{
		[JsonProperty]
		public string Value { get; set; }

		public TextFragmentData(Guid iD,
			Guid templateID,
			string value) : base(iD, templateID)
		{
			Value = value;
		}
	}
}