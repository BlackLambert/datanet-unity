using SBaier.Datanet.Core;
using System;
using System.Collections;
using System.Collections.Generic;
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
			_dataNet.NodeContainer.OnNodeAdded += onNodesCountChanged;
			_dataNet.NodeContainer.OnNodeRemoved += onNodesCountChanged;
		}

		protected virtual void OnDestroy()
		{
			_dataNet.NodeContainer.OnNodeAdded -= onNodesCountChanged;
			_dataNet.NodeContainer.OnNodeRemoved -= onNodesCountChanged;
		}

		private void onNodesCountChanged(Node _)
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
			_counterText.text = _dataNet.NodeContainer.Count.ToString();
		}
	}
}