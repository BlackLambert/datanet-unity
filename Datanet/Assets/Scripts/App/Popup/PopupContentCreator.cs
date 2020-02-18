using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupContentCreator : MonoBehaviour
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

		private PopupContent _popupContentPrefab;
		private PrefabFactory _prefabFactory;

		[Inject]
		private void Construct(PopupContent popupContentPrefab,
			PrefabFactory prefabFactory)
		{
			_popupContentPrefab = popupContentPrefab;
			_prefabFactory = prefabFactory;
		}

		protected virtual void Start()
		{
			PopupContent content = _prefabFactory.Create(_popupContentPrefab);
			content.Base.SetParent(Hook, false);
		}
	}
}