

using SBaier.Datanet.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class SelectNetOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		private SelectedDataNet _selectedDataNet;
		private DataNet _dataNet;


		[Inject]
		public void Construct(SelectedDataNet selectedDataNet,
			DataNet dataNet)
		{
			_selectedDataNet = selectedDataNet;
			_dataNet = dataNet;
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
			setSelectedNet();
		}

		private void setSelectedNet()
		{
			_selectedDataNet.Selected = _dataNet;
		}
	}
}