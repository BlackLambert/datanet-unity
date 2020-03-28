using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentInfoDescriptionDisplayer : MonoBehaviour
	{
		private FragmentInfo _fragmentInfo;

		[SerializeField]
		private TextMeshProUGUI _text = null;

		[Inject]
		private void Construct(FragmentInfo fragmentInfo)
		{
			_fragmentInfo = fragmentInfo;
		}

		protected virtual void Start()
		{
			_text.text = _fragmentInfo.Description;
		}
	}
}