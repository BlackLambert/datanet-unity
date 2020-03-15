using System;
using UnityEngine;
using Zenject;

namespace SBaier.UI
{
	public class BasicViewAnimator : ViewAnimator
	{
		[SerializeField]
		private GameObject _base = null;
		public GameObject Base { get { return _base; } }

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

		public override void HideImmediatly()
		{
			Hide();
		}
	}
}