using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	
	public class TextFragment : ComponentFragment
	{
		public TextFragment(TextFragmentData data, TextFragmentTemplate template): base()
		{
			Data = data;
			Template = template;
		}

		public string Value
		{
			get
			{
				if (Editable)
					return Template.DefaultValue;
				return Data.Value;
			}
			set
			{
				if (!Editable)
					throw new InvalidOperationException($"This {nameof(TextFragment)} is not editable. " +
						$"Therefore setting the {nameof(Value)} is not allowed!");
				Data.Value = value;
			}
		}

		public bool Editable { get { return Template.Editable; } }
		public override Guid ID { get { return Data.ID; } }
		public TextFragmentTemplate Template { get; private set; }
		public TextFragmentData Data { get; private set; }
	}
}