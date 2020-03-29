using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class TextFragmentDefaultValueInput : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputField = null;
		private TextFragmentTemplate _template;

		[Inject]
		private void Construct(TextFragmentTemplate template)
		{
			_template = template;
		}

		protected virtual void Start()
		{
			_inputField.text = _template.DefaultValue;
			_inputField.onValueChanged.AddListener(changeEditable);
			_template.OnDefaultValueChanged += changeView;
		}

		protected virtual void OnDestroy()
		{
			_inputField.onValueChanged.RemoveListener(changeEditable);
			_template.OnDefaultValueChanged -= changeView;
		}

		private void changeEditable(string value)
		{
			if (_template.DefaultValue == value)
				return;
			_template.DefaultValue = value;
		}

		private void changeView(TextFragmentTemplate caller, string former, string newValue)
		{
			if (_inputField.text == newValue)
				return;
			_inputField.text = newValue;
		}
	}
}