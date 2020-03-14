using System;
using UnityEngine;

namespace SBaier.UI
{
	public class BasicViewAnimator : ViewAnimator
	{
		[SerializeField]
		private GameObject _base = null;

		public override event Action OnHidden;

		public override void Display()
		{
			_base.SetActive(true);
		}

		public override void Hide()
		{
			_base.SetActive(false);
			OnHidden?.Invoke();
		}
	}
}