using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI
{
	public abstract class DisplayViewOnClick<TView> : MonoBehaviour where TView : View
	{
		[SerializeField]
		private Button _button = null;

		private ViewDisplayer<TView> _viewDisplayer;

		[Inject]
		private void Construct(ViewDisplayer<TView> viewDisplayer)
		{
			_viewDisplayer = viewDisplayer;
		}

		protected virtual void Start()
		{
			_button.onClick.AddListener(display);
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveListener(display);
		}


		private void display()
		{
			TView view = loadView();
			_viewDisplayer.Display(view);
		}

		protected abstract TView loadView();
	}

}