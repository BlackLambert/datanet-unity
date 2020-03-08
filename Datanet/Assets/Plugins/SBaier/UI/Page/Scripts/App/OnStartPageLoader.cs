using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.UI.Page
{
	public class OnStartPageLoader : MonoBehaviour
	{
		private string _pagePath;
		private PageViewDisplayer _pageViewDisplayer;
		private PrefabFactory _prefabFactory;

		[Inject]
		private void Construct(string pagePath,
			PageViewDisplayer pageViewDisplayer,
			PrefabFactory prefabFactory)
		{
			_pagePath = pagePath;
			_pageViewDisplayer = pageViewDisplayer;
			_prefabFactory = prefabFactory;
		}


		protected virtual void Start()
		{
			GameObject pageObjectPrefab = Resources.Load<GameObject>(_pagePath);
			GameObject pageObject = _prefabFactory.Create(pageObjectPrefab);
			Page page = pageObject.GetComponentInChildren<Page>();
			if (page == null)
				throw new ArgumentException($"The reasource to load needs to have a {nameof(Page)} Component attached to it.");
			_pageViewDisplayer.Display(page);
		}
	}
}