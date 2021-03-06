﻿using System;
using UnityEngine;

namespace SBaier.UI
{
	public abstract class View : MonoBehaviour
	{
		[SerializeField]
		private ViewAnimator _animator = null;
		[SerializeField]
		protected bool _hideOnAwake = true;

		public event Action OnHidden;
		public abstract Transform Base { get; }

		protected virtual void Awake()
		{
			if (_hideOnAwake)
				_animator.HideImmediatly();
		}

		public void Display()
		{
			_animator.Display();
		}

		public void Display(bool display)
		{
			if (display)
				Display();
			else
				Hide();
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