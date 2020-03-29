using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentIDDisplayer : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private ComponentFragmentTemplate _fragmentTemplate;

		[Inject]
		private void Construct(ComponentFragmentTemplate fragmentTemplate)
		{
			_fragmentTemplate = fragmentTemplate;
		}

		protected virtual void Start()
		{
			_text.text = _fragmentTemplate.ID.ToString();
		}
	}
}