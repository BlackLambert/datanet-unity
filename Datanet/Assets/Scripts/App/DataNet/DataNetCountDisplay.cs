﻿

using UnityEngine;
using Zenject;
using TMPro;
using SBaier.Datanet.Core;
using System.Collections.Generic;
using System;

namespace SBaier.Datanet
{
	public class DataNetCountDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private DataNetsRepository _netsReporitory;

		[Inject]
		private void Construct(DataNetsRepository netContainer)
		{
			_netsReporitory = netContainer;
		}


		protected virtual void Start()
		{
			updateText();
			_netsReporitory.OnCollectionContentAdded += onNetContainerContentChange;
			_netsReporitory.OnCollectionContentRemoved += onNetContainerContentChange;
		}

		protected virtual void OnDestroy()
		{
			_netsReporitory.OnCollectionContentAdded -= onNetContainerContentChange;
			_netsReporitory.OnCollectionContentRemoved -= onNetContainerContentChange;
		}

		private void onNetContainerContentChange(KeyValuePair<Guid, DataNet> net)
		{
			updateText();
		}

		private void updateText()
		{
			_text.text = _netsReporitory.Count.ToString();
		}
	}
}