using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentTemplateNameInput : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputField = null;
		private NodeComponentTemplate _template;

		[Inject]
		private void Construct(NodeComponentTemplate template)
		{
			_template = template;
		}

		protected virtual void Start()
		{
			_inputField.text = _template.Name;
			_inputField.onValueChanged.AddListener(changeEditable);
			_template.OnNameChanged += changeView;
		}

		protected virtual void OnDestroy()
		{
			_inputField.onValueChanged.RemoveListener(changeEditable);
			_template.OnNameChanged -= changeView;
		}

		private void changeEditable(string value)
		{
			if (_template.Name == value)
				return;
			_template.Name = value;
		}

		private void changeView(NodeComponentTemplate caller, string former, string newValue)
		{
			if (_inputField.text == newValue)
				return;
			_inputField.text = newValue;
		}
	}
}