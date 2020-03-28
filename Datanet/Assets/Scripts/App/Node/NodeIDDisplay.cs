using UnityEngine;
using TMPro;
using SBaier.Datanet;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeIDDisplay : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private Node _node;


		[Inject]
		private void Construct(Node node)
		{
			_node = node;
		}

		protected virtual void Start()
		{
			_text.text = _node.ID.ToString();
		}
	}
}