

using UnityEngine;

namespace SBaier.Testing.UI
{
	public class UITestCanvas : MonoBehaviour
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }
	}
}