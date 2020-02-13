

using SBaier.Datanet.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class DataNetCreationButton: MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;

		private DataNetFactory _dataNetFactory;
		private DataNetContainer _dataNetContainer;
		private DataNetCreationData _creationData;
		private DataNetNameValidator _nameValidator;

		[Inject]
		private void Construct(DataNetFactory netFactory,
			DataNetContainer dataNetContainer,
			DataNetCreationData creationData,
			DataNetNameValidator nameValidator)
		{
			_dataNetFactory = netFactory;
			_dataNetContainer = dataNetContainer;
			_creationData = creationData;
			_nameValidator = nameValidator;
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
			_nameValidator.Validate(_creationData.Name, _dataNetContainer.DataNetsCopy);
			DataNetFactory.Parameter parameter = new DataNetFactory.Parameter(_creationData.Name);
			DataNet result = _dataNetFactory.Create(parameter);
			_dataNetContainer.AddDataNet(result);
		}
	}
}