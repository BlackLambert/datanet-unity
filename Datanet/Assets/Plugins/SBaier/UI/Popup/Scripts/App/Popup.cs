

using UnityEngine;

namespace SBaier.UI.Popup
{
	public class Popup : View
	{
		[SerializeField]
		private Transform _base = null;
		public override Transform Base => _base;
	}
}