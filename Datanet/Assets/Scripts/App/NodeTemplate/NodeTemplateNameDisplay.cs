using SBaier.Datanet.Core;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeTemplateNameDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private NodeTemplate _nodeTemplate;

		[Inject]
		private void Construct(NodeTemplate nodeTemplate)
		{
			_nodeTemplate = nodeTemplate;
		}

		protected virtual void Start()
		{
			setName();
		}

		private void setName()
		{
			_text.text = _nodeTemplate.Name;
		}
	}
}