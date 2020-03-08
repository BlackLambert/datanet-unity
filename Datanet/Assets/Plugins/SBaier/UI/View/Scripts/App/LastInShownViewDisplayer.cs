using System;
using System.Collections.Generic;

namespace SBaier.UI
{
	public class LastInShownViewDisplayer<TView> : ViewDisplayer<TView> where TView : View
	{
		private List<TView> _views = new List<TView>();
		private TView _currentlyDisplayedView = default(TView);


		public void Display(TView view)
		{
			if(_views.Contains(view))
				throw new ArgumentException($"The view is already managed by this {nameof(LastInShownViewDisplayer<TView>)}");
			hideCurrentlyDisplayedView();
			_views.Add(view);
			showLastAddedView();
		}

		public void Hide(TView view)
		{
			if (!_views.Contains(view))
				throw new ArgumentException($"The view is not managed by this {nameof(LastInShownViewDisplayer<TView>)}");
			if (_views[_views.Count - 1] == view)
			{
				Hide();
				return;
			}
			_views.Remove(view);
			view.Hide();
			showLastAddedView();
		}

		public void Hide()
		{
			if (_currentlyDisplayedView == null)
				throw new InvalidOperationException("There is no view currently displayed");
			hideCurrentlyDisplayedView();
			showLastAddedView();
		}

		private void showLastAddedView()
		{
			if (_views.Count == 0)
				return;
			_currentlyDisplayedView = _views[_views.Count - 1];
			_currentlyDisplayedView.Display();
		}

		private void hideCurrentlyDisplayedView()
		{
			if (_currentlyDisplayedView == null)
				return;
			_currentlyDisplayedView.Hide();
			_views.Remove(_currentlyDisplayedView);
			_currentlyDisplayedView = null;
		}
	}
}