

using SBaier.Datanet.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class SelectedDataNetNameDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;
		public TextMeshProUGUI Text { get { return _text; } }

		private SelectedDataNet _selectedDataNet;


		[Inject]
		public void Construct(SelectedDataNet selectedDataNet)
		{
			_selectedDataNet = selectedDataNet;
		}

		protected virtual void Start()
		{
			_selectedDataNet.OnSelectedChanged += onSelectedNetChange;
			updateText();
		}

		protected virtual void OnDestroy()
		{
			if(_selectedDataNet != null)
				_selectedDataNet.OnSelectedChanged -= onSelectedNetChange;
		}

		private void onSelectedNetChange(DataNet formerNet, DataNet newNet)
		{
			updateText();
		}

		private void updateText()
		{
			_text.text = _selectedDataNet.Selected.Name;
		}
	}
}