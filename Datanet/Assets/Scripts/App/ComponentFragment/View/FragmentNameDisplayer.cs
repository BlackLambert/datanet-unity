using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentNameDisplayer : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text = null;

		private FragmentInfo _info;

		[Inject]
		private void Construct(FragmentInfo info)
		{
			_info = info;
		}

		protected virtual void Start()
		{
			_text.text = _info.Name;
		}
	}
}