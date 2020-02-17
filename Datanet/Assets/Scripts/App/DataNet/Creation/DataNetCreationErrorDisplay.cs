

using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetCreationErrorDisplay: MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _textField = null;
		public TextMeshProUGUI TextField { get { return _textField; } }

		private DataNetCreationData _creationData;
		public DataNetCreationData CreationData { get { return _creationData; } }

		[Inject]
		public void Construct(DataNetCreationData creationData)
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

		private void onErrorChanged()
		{
			updateText();
		}

		private void updateText()
		{
			_textField.text = _creationData.Error;
		}
	}
}