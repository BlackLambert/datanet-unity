using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.Datanet
{
	public class AddFragmentTemplateToComponentTemplateOnClick : MonoBehaviour
	{
		private NodeComponentTemplate _componentTemplate;
		private FragmentInfo _info;
		private ComponentFragmentTemplateFactory _templateFactory;


		[SerializeField]
		private Button _button = null;

		[Inject]
		private void Construct(NodeComponentTemplate componentTemplate,
			FragmentInfo info,
			ComponentFragmentTemplateFactory templateFactory)
		{
			_componentTemplate = componentTemplate;
			_info = info;
			_templateFactory = templateFactory;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(addFragmentTemplate);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(addFragmentTemplate);
		}

		private void addFragmentTemplate()
		{
			ComponentFragmentTemplate tempalte = _templateFactory.Create(_info.Type);
			_componentTemplate.AddFragmentTemplate(tempalte.ID);
		}
	}
}