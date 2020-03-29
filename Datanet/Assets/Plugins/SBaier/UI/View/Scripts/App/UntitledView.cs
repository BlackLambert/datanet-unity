
using UnityEngine;

namespace SBaier.UI
{
	public class UntitledView : View
	{
		[SerializeField]
		private Transform _base = null;
		public override Transform Base => _base;
	}
}