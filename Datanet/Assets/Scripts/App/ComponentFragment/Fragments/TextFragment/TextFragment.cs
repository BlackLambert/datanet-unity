using System;

namespace SBaier.Datanet.Core
{
	public class TextFragment : ComponentFragment
	{
		public TextFragment(Guid iD, TextFragmentTemplate template): base(iD)
		{
			_value = template.DefaultValue;
			Template = template;
		}

		private string _value;
		public string Value
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

		public bool Editable { get { return Template.Editable; } }
		public TextFragmentTemplate Template { get; private set; }
	}
}