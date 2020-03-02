using System;

namespace SBaier.Datanet.Core
{
	public class DateFragment : ComponentFragment
	{
		private DateTime _value;
		public DateTime Value
		{
			get
			{
				if (Editable)
					return Template.DefaultValue;
				return _value;
			}
			set
			{
				if (!Editable)
					throw new InvalidOperationException($"This {nameof(DateFragment)} is not editable. " +
						$"Therefore setting the {nameof(Value)} is not allowed!");
				_value = value;
			}
		}
		public string Format { get { return Template.Format; } }
		public bool Editable { get { return Template.Editable; } }
		public DateFragmentTemplate Template { get; private set; }

		public DateFragment(Guid iD, DateFragmentTemplate template) : base(iD)
		{
			Template = template;
			_value = template.DefaultValue;
		}
	}
}