using System;
using UnityEngine;

namespace SBaier.UI
{
	public abstract class View : MonoBehaviour
	{
		[SerializeField]
		private ViewAnimator _animator = null;

		public event Action OnHidden;

		public void Display()
		{
			_animator.Display();
		}

		protected void OnDestroy()
		{
			_animator.OnHidden -= onHidden;
		}

		public void Hide()
		{
			_animator.OnHidden += onHidden;
			_animator.Hide();
		}

		private void onHidden()
		{
			_animator.OnHidden -= onHidden;
			OnHidden?.Invoke();
		}
	}
}