using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class TextFragmentEditableToggle : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggle = null;
		private TextFragmentTemplate _template;

		[Inject]
		private void Construct(TextFragmentTemplate template)
		{
			_template = template;
		}

		protected virtual void Start()
		{
			_toggle.isOn = _template.Editable;
			_toggle.onValueChanged.AddListener(changeEditable);
			_template.OnEditbaleChanged += changeView;
		}

		protected virtual void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(changeEditable);
			_template.OnEditbaleChanged -= changeView;
		}

		private void changeEditable(bool value)
		{
			if (_template.Editable == value)
				return;
			_template.Editable = value;
		}

		private void changeView(TextFragmentTemplate caller, bool former, bool newValue)
		{
			if (_toggle.isOn == newValue)
				return;
			_toggle.isOn = newValue;
		}
	}
}