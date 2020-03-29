using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class RemoveFragmentOnClick : MonoBehaviour
	{
		[SerializeField]
		private Button _button = null;

		private NodeComponentTemplate _componentTemplate;
		private ComponentFragmentTemplate _fragmentTemplate;
		private FragmentTemplateDestructor _destructor;

		[Inject]
		private void Construct(NodeComponentTemplate componentTemplate,
			ComponentFragmentTemplate fragmentTemplate,
			FragmentTemplateDestructor destructor)
		{
			_componentTemplate = componentTemplate;
			_fragmentTemplate = fragmentTemplate;
			_destructor = destructor;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(remove); 
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(remove);
		}

		private void remove()
		{
			_componentTemplate.RemoveFragmentTemplate(_fragmentTemplate.ID);
			_destructor.Destruct(_fragmentTemplate);
		}
	}
}