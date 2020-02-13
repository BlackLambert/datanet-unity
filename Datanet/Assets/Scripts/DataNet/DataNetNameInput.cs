

using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetNameInput: MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _input = null;

		private DataNetCreationData _netCreationData;

		[Inject]
		private void Construct(DataNetCreationData netCreationData)
		{
			_netCreationData = netCreationData;
		}


		protected virtual void Start()
		{
			_netCreationData.OnNameChanged += onNameChanged;
			_input.onEndEdit.AddListener(onInputValueEdited);
			_input.onValueChanged.AddListener(onInputValueChanged);
		}

		protected virtual void OnDestroy()
		{
			_netCreationData.OnNameChanged += onNameChanged;
			_input.onEndEdit.RemoveListener(onInputValueEdited);
			_input.onValueChanged.RemoveListener(onInputValueChanged);
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
			_input.text = _netCreationData.Name;
		}
	}
}