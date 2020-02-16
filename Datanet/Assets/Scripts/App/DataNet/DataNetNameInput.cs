

using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetNameInput: MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputField = null;
		public TMP_InputField InputField { get { return _inputField; } }

		private DataNetCreationData _netCreationData;

		[Inject]
		public void Construct(DataNetCreationData netCreationData)
		{
			_netCreationData = netCreationData;
		}


		protected virtual void Start()
		{
			_netCreationData.OnNameChanged += onNameChanged;
			_inputField.onEndEdit.AddListener(onInputValueEdited);
			_inputField.onValueChanged.AddListener(onInputValueChanged);
		}

		protected virtual void OnDestroy()
		{
			_netCreationData.OnNameChanged -= onNameChanged;
			_inputField.onEndEdit.RemoveListener(onInputValueEdited);
			_inputField.onValueChanged.RemoveListener(onInputValueChanged);
		}

		private void onInputValueEdited(string value)
		{
			_netCreationData.Name = value;
		}

		private void onInputValueChanged(string value)
		{
			_netCreationData.Error = string.Empty;
		}

		private void onNameChanged()
		{
			_inputField.text = _netCreationData.Name;
		}
	}
}