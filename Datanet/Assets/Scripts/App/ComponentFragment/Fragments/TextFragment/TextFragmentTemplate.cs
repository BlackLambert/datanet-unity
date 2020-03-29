using Newtonsoft.Json;
using System;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class TextFragmentTemplate : ComponentFragmentTemplate
	{
		[JsonProperty]
		private string _defaultValue = "";
		public string DefaultValue
		{
			get { return _defaultValue; }
			set
			{
				string former = _defaultValue;
				_defaultValue = value;
				OnDefaultValueChanged?.Invoke(this, former, _defaultValue);
			}
		}
		public OnPropertyChangedAction<TextFragmentTemplate, string> OnDefaultValueChanged;

		[JsonProperty]
		private bool _editable = true;
		public bool Editable {
			get { return _editable; }
			set 
			{
				bool former = _editable;
				_editable = value;
				OnEditbaleChanged?.Invoke(this, former, _editable);
			}
		}
		public OnPropertyChangedAction<TextFragmentTemplate, bool> OnEditbaleChanged;

		public TextFragmentTemplate(Guid iD, ComponentFragmentType type, string defaultValue, bool editable) : base(iD, type)
		{
			DefaultValue = defaultValue;
			Editable = editable;
		}
	}
}