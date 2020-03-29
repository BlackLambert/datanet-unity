

using UnityEngine;

namespace SBaier.UI.Test
{
	public class TestView : View
	{
		[SerializeField]
		private Transform _base = null;
		public override Transform Base => _base;
	}
}