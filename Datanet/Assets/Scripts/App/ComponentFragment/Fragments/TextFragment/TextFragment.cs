using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	
	public class TextFragment : ComponentFragment
	{
		private TextFragmentTemplate _template;
		private TextFragmentData _data;
		private FragmentInfo _info;

		public TextFragment(TextFragmentData data, TextFragmentTemplate template,
			FragmentInfo info) : base()
		{
			_data = data;
			_template = template;
			_info = info;
		}

		public string Value
		{
			get
			{
				if (Editable)
					return _template.DefaultValue;
				return _data.Value;
			}
			set
			{
				if (!Editable)
					throw new InvalidOperationException($"This {nameof(TextFragment)} is not editable. " +
						$"Therefore setting the {nameof(Value)} is not allowed!");
				_data.Value = value;
			}
		}

		public bool Editable { get { return _template.Editable; } }
		public override Guid ID { get { return _data.ID; } }
		public override string Name => _info.Name;
	}
}