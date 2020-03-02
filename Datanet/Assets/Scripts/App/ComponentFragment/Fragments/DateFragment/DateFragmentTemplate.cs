using System;

namespace SBaier.Datanet.Core
{
	public class DateFragmentTemplate : ComponentFragmentTemplate
	{
		public DateTime DefaultValue { get; private set; }
		public string Format { get; private set; }
		public bool Editable { get; private set; }

		public DateFragmentTemplate(Guid iD, DateTime defaultValue, string format, bool editable) : base(iD)
		{
			DefaultValue = defaultValue;
			Format = format;
			Editable = editable;
		}
	}
}