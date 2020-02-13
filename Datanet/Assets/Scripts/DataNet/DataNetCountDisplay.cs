

using UnityEngine;
using Zenject;
using TMPro;
using SBaier.Datanet.Core;

namespace SBaier.Datanet
{
	public class DataNetCountDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private DataNetContainer _netContainer;

		[Inject]
		private void Construct(DataNetContainer netContainer)
		{
			_netContainer = netContainer;
		}


		protected virtual void Start()
		{
			updateText();
			_netContainer.OnNetAdded += onNetContainerContentChange;
			_netContainer.OnNetRemoved += onNetContainerContentChange;
		}

		protected virtual void OnDestroy()
		{
			_netContainer.OnNetAdded -= onNetContainerContentChange;
			_netContainer.OnNetRemoved -= onNetContainerContentChange;
		}

		private void onNetContainerContentChange(DataNet net)
		{
			updateText();
		}

		private void updateText()
		{
			_text.text = _netContainer.Count.ToString();
		}
	}
}