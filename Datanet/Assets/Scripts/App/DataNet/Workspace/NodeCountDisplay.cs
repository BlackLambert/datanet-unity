using SBaier.Datanet.Core;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeCountDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _counterText = null;
		public TextMeshProUGUI CounterText { get { return _counterText; } }

		private DataNet _dataNet;

		[Inject]
		private void Construct(DataNet dataNet)
		{
			_dataNet = dataNet;
		}

		protected virtual void Start()
		{
			updateCounterText();
			_dataNet.OnNodeIDAdded += onNodesCountChanged;
			_dataNet.OnNodeIDRemoved += onNodesCountChanged;
		}

		protected virtual void OnDestroy()
		{
			_dataNet.OnNodeIDAdded -= onNodesCountChanged;
			_dataNet.OnNodeIDRemoved -= onNodesCountChanged;
		}

		private void onNodesCountChanged(Guid _)
		{
			updateCounterText();
		}

		private void updateCounterText()
		{
			if(_dataNet == null)
			{
				_counterText.text = 0.ToString();
				return;
			}
			_counterText.text = _dataNet.Count.ToString();
		}
	}
}