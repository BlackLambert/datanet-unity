

using SBaier.Datanet.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetNameDisplay: MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		private DataNet _dataNet;


		[Inject]
		private void Construct(DataNet dataNet)
		{
			_dataNet = dataNet; 
		}


		protected virtual void Start()
		{
			_text.text = _dataNet.Name;
		}

		protected virtual void OnDestroy()
		{

		}
	}
}