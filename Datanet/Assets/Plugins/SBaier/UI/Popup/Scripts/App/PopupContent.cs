using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.UI.Popup
{
	public class PopupContent : MonoBehaviour
	{
		[SerializeField]
		private Transform _base =null;
		public Transform Base { get { return _base; } }
	}
}