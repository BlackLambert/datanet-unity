

using SBaier.Datanet.Core;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetCreationButton: MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		private DataNetFactory _dataNetFactory;
		private DataNetsRepository _dataNetContainer;
		private DataNetCreationData _creationData;

		[Inject]
		public void Construct(DataNetFactory netFactory,
			DataNetsRepository dataNetsRepository,
			DataNetCreationData creationData)
		{
			_dataNetFactory = netFactory;
			_dataNetContainer = dataNetsRepository;
			_creationData = creationData;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(tryCreateNet);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(tryCreateNet);
		}

		private void tryCreateNet()
		{
			try
			{
				createNet();
				_creationData.Error = string.Empty;
				_creationData.Name = string.Empty;
			}
			catch (Exception e)
			{
				_creationData.Error = e.Message;
			}
		}

		private void createNet()
		{
			DataNetFactory.Parameter parameter = new DataNetFactory.Parameter(_creationData.Name);
			DataNet result = _dataNetFactory.Create(parameter);
			_dataNetContainer.Add(result.ID, result);
		}
	}
}