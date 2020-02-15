

using SBaier.Datanet.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetNameDisplay: MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;
		public TextMeshProUGUI Text { get { return _text; } }

		private DataNet _dataNet;


		[Inject]
		public void Construct(DataNet dataNet)
		{
			_dataNet = dataNet; 
		}


		protected virtual void Start()
		{
			updateText();
			_dataNet.OnNameChanged += onNetNameChanged;
		}

		protected virtual void OnDestroy()
		{
			_dataNet.OnNameChanged -= onNetNameChanged;
		}

		private void onNetNameChanged()
		{
			updateText();
		}

		private void updateText()
		{
			_text.text = _dataNet.Name;
		}
	}
}