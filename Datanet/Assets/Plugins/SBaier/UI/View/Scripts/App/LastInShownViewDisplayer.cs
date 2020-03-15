using System;
using System.Collections.Generic;

namespace SBaier.UI
{
	public class LastInShownViewDisplayer<TView> : ViewDisplayer<TView> where TView : View
	{
		private List<TView> _views = new List<TView>();
		public List<TView> ViewsCopy { get { return new List<TView>(_views); } }
		private TView _currentlyDisplayedView = default(TView);
		public TView CurrentlyDisplayedView { get { return _currentlyDisplayedView; } }


		public void Display(TView view)
		{
			if (view == null)
				throw new ArgumentNullException("The provided view is null");
			if (_currentlyDisplayedView == view)
				return;

			hideCurrentlyDisplayedView();

			if (_views.Contains(view))
				_views.Remove(view);

			_views.Add(view);
			showLastAddedView();
		}

		public void Hide(TView view)
		{
			if (view == null)
				throw new ArgumentNullException("The provided view is null");
			if (!_views.Contains(view))
				throw new ArgumentException($"The view is not managed by this {nameof(LastInShownViewDisplayer<TView>)}");
			if (_currentlyDisplayedView == view)
			{
				Hide();
				return;
			}
			_views.Remove(view);
		}

		public void Hide()
		{
			if (_currentlyDisplayedView == null)
				throw new InvalidOperationException("There is no view currently displayed");
			_views.Remove(_currentlyDisplayedView);
			hideCurrentlyDisplayedView();
			showLastAddedView();
		}

		private void showLastAddedView()
		{
			if (_views.Count == 0)
				return;
			showView(_views[_views.Count - 1]);
		}

		private void showView(TView view)
		{
			_currentlyDisplayedView = view;
			_currentlyDisplayedView.Display();
		}

		private void hideCurrentlyDisplayedView()
		{
			if (_currentlyDisplayedView == null)
				return;
			_currentlyDisplayedView.Hide();
			_currentlyDisplayedView = null;
		}
	}
}