
using UnityEngine;
using Zenject;

namespace SBaier.UI
{
	public abstract class ViewDestructor<TView> where TView : View
	{
		private ViewDisplayer<TView> _viewDisplayer;

		protected abstract TView ViewToClose { get; }

		[Inject]
		private void Construct(
			ViewDisplayer<TView> viewDisplayer)
		{
			_viewDisplayer = viewDisplayer;
		}



		public void Destruct()
		{
			ViewToClose.OnHidden += destroy;
			_viewDisplayer.Hide(ViewToClose);
		}

		private void destroy()
		{
			ViewToClose.OnHidden -= destroy;
			GameObject.Destroy(ViewToClose.Base.gameObject);
		}
	}
}