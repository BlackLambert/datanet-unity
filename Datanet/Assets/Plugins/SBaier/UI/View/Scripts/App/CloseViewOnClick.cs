using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SBaier.UI
{
	public abstract class CloseViewOnClick<TView> : MonoBehaviour where TView : View
	{
		[SerializeField]
		private Button _button = null;
		public Button Button { get { return _button; } }

		private ViewDestructor<TView> _viewDestructor;

		[Inject]
		private void Construct(
			ViewDestructor<TView> viewDestructor)
		{
			_viewDestructor = viewDestructor;
		}

		protected virtual void OnEnable()
		{
			Button.onClick.AddListener(onClick);
		}

		protected virtual void OnDisable()
		{
			Button.onClick.RemoveListener(onClick);
		}

		private void onClick()
		{
			_viewDestructor.Destruct();
		}
	}
}