using System;
using UnityEngine;
using Zenject;

namespace SBaier.UI.Page
{
	public class OnStartPageLoader : MonoBehaviour
	{
		private string _pagePath;
		private PageViewDisplayer _pageViewDisplayer;
		private PageFromResourceLoader _pageLoader;

		[Inject]
		private void Construct(string pagePath,
			PageViewDisplayer pageViewDisplayer,
			PageFromResourceLoader pageLoader)
		{
			_pagePath = pagePath;
			_pageViewDisplayer = pageViewDisplayer;
			_pageLoader = pageLoader;
		}


		protected virtual void Start()
		{
			Page page = _pageLoader.Load(_pagePath);
			_pageViewDisplayer.Display(page);
		}
	}
}