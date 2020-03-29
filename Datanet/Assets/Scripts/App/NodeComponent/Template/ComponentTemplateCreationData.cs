using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	public class ComponentTemplateCreationData
	{
		private string _error;
		public string Error
		{
			get { return _error; }
			set
			{
				string former = _error;
				_error = value;
				OnErrorChanged(this, former, _error);
			}
		}

		public OnPropertyChangedAction<ComponentTemplateCreationData, string> OnErrorChanged;

		public NodeComponentTemplate Template { get; private set; }

		public ComponentTemplateCreationData(NodeComponentTemplate template)
		{
			Template = template;
		}
	}
}