using System;
using UnityEngine;
using Zenject;

namespace SBaier.UI
{
	public abstract class ViewFromResourcesLoader<TView> where TView: View 
	{
		private PrefabFactory _prefabFactory;

		[Inject]
		private void Construct(
			PrefabFactory prefabFactory)
		{
			_prefabFactory = prefabFactory;
		}

		public TView Load(string path, PrefabFactory.Parameter[] parameters = null)
		{
			GameObject viewObjectPrefab = Resources.Load<GameObject>(path);
			if (parameters == null)
				parameters = new PrefabFactory.Parameter[0];
			GameObject viewObject = _prefabFactory.Create(viewObjectPrefab, parameters);
			TView view = viewObject.GetComponentInChildren<TView>();
			if (view == null)
				throw new ArgumentException($"The resource to load needs to have a {nameof(TView)} Component attached to it.");
			return view;
		}
	}
}