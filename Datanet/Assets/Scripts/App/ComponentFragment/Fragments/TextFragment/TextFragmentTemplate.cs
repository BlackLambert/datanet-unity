using System;

namespace SBaier.Datanet.Core
{
	[Serializable]
	public class TextFragmentTemplate : ComponentFragmentTemplate
	{
		public string DefaultValue { get; private set; }
		public bool Editable { get; private set; }

		public TextFragmentTemplate(Guid iD, string defaultValue, bool editable) : base(iD)
		{
			DefaultValue = defaultValue;
			Editable = editable;
		}
	}
}