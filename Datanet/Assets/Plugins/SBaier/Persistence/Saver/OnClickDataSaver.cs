using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Persistence
{
	public class OnClickDataSaver : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;

		private DataSaver _dataSaver;

		[Inject]
		private void Construct(DataSaver dataSaver)
		{
			_dataSaver = dataSaver;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			save();
		}

		private async void save()
		{
			await _dataSaver.Save();
		}
	}
}