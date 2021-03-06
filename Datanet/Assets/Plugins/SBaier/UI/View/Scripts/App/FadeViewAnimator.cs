﻿
using System;
using UnityEngine;
using Zenject;

namespace SBaier.UI
{
	public class FadeViewAnimator : ViewAnimator
	{
		[SerializeField]
		private CanvasGroup _canvasGroup = null;
		public CanvasGroup CanvasGroup { get { return _canvasGroup; } }
		[SerializeField]
		private Transform _base = null;
		public Transform Base { get { return _base; } }
		[SerializeField]
		private float _fadeInDuration = 0.33f;
		public float FadeInDuration { get { return _fadeInDuration; } }
		[SerializeField]
		private float _fadeOutDuration = 0.25f;
		public float FadeOutDuration { get { return _fadeOutDuration; } }

		private float _delta = 0;
		private State _state = State.Idle;

		public override event Action OnHidden;


		protected virtual void Update()
		{
			_delta = calculateDelta();
			if (_delta != 0)
				fade();
		}

		public override void Display()
		{
			_state = State.FadingIn;
			_canvasGroup.interactable = true;
			_base.gameObject.SetActive(true);
		}

		public override void Hide()
		{
			_state = State.FadingOut;
			_canvasGroup.interactable = false;
		}

		private void fade()
		{
			_canvasGroup.alpha = Mathf.Clamp01(_canvasGroup.alpha + _delta);
			checkFinishAnimation();
		}

		private void checkFinishAnimation()
		{
			switch(_state)
			{
				case State.FadingIn:
					if (_canvasGroup.alpha != 1)
						return;
					finishDisplay();
					break;
				case State.FadingOut:
					if (_canvasGroup.alpha != 0)
						return;
					finishHide();
					break;
				default:
					return;
			}
		}


		private void finishDisplay()
		{
			_state = State.Idle;
			
		}

		private void finishHide()
		{
			_state = State.Idle;
			_base.gameObject.SetActive(false);
			OnHidden?.Invoke();
		}


		private float calculateDelta()
		{
			switch (_state) 
			{
				case State.Idle:
					return 0;
				case State.FadingIn:
					return Time.deltaTime / _fadeInDuration;
				case State.FadingOut:
					return (Time.deltaTime * (-1)) / _fadeOutDuration;
				default: 
					return 0;
			};
		}

		public override void HideImmediatly()
		{
			_canvasGroup.alpha = 0;
			_canvasGroup.interactable = false;
			finishHide();
		}

		private enum State
		{
			Idle = 0,
			FadingIn = 1,
			FadingOut = 2
		}
	}
}