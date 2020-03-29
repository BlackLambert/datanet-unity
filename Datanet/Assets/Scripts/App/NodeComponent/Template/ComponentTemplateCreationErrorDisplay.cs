using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class ComponentTemplateCreationErrorDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _textField = null;
		public TextMeshProUGUI TextField { get { return _textField; } }

		private ComponentTemplateCreationData _creationData;
		public ComponentTemplateCreationData CreationData { get { return _creationData; } }

		[Inject]
		public void Construct(ComponentTemplateCreationData creationData)
		{
			_creationData = creationData;
		}

		protected virtual void Start()
		{
			_creationData.OnErrorChanged += onErrorChanged;
			updateText();
		}

		protected virtual void OnDestroy()
		{
			_creationData.OnErrorChanged -= onErrorChanged;
		}

		private void onErrorChanged(ComponentTemplateCreationData caller, string former, string newValue)
		{
			updateText();
		}

		private void updateText()
		{
			_textField.text = _creationData.Error;
		}
	}
}