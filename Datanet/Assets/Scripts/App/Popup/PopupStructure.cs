using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Popup
{
	public class PopupStructure : MonoBehaviour
	{
		[SerializeField]
		private Transform _contentHook = null;
		public Transform ContentHook { get { return _contentHook; } }
		
		[SerializeField]
		private Transform _base = null;
		public Transform Base { get { return _base; } }
	}
}