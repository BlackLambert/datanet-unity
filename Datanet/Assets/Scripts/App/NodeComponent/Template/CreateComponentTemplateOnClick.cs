using SBaier.Persistence;
using SBaier.UI.Page;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class CreateComponentTemplateOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;

		private DataSaver _saver = null;
		private ComponentTemplateCreationData _creationData;
		private PageDestructor _pageDestructor;

		[Inject]
		private void Construct(ComponentTemplateCreationData creationData,
			DataSaver dataSaver,
			PageDestructor pageDestructor)
		{
			_creationData = creationData;
			_saver = dataSaver;
			_pageDestructor = pageDestructor;
		}

		protected virtual void OnEnable()
		{
			_button.onClick.AddListener(onClick);
		}

		protected virtual void OnDisable()
		{
			_button.onClick.RemoveListener(onClick);
		}

		private async void onClick()
		{
			_button.interactable = false;
			validateCreationData();

			if (!string.IsNullOrEmpty(_creationData.Error))
			{
				_button.interactable = true;
				return;
			}

			await _saver.Save();
			_pageDestructor.Destruct();
		}

		private void validateCreationData()
		{
			if (string.IsNullOrEmpty(_creationData.Template.Name))
				_creationData.Error = "Please choose a name for the new component";
			else if (_creationData.Template.FragmentTemplateIDsCopy.Count == 0)
				_creationData.Error = "Please choose at least one fragment for the new component.";
			else
				_creationData.Error = string.Empty;
		}
	}
}