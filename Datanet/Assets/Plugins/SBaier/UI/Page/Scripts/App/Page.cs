
using UnityEngine;

namespace SBaier.UI.Page
{
	public class Page : View
	{
		[SerializeField]
		private Transform _base = null;
		public override Transform Base => _base;
	}
}