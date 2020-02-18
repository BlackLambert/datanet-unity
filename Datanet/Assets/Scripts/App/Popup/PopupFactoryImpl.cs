using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Popup
{
	public class PopupFactoryImpl : PopupFactory
	{
		private PrefabFactory _prefabFactory;

		[Inject]
		private void Construct(PrefabFactory prefabFactory)
		{
			_prefabFactory = prefabFactory;
		}


		public override PopupInstaller Create(PopupCreationData creationData)
		{
			PrefabFactory.Parameter[] parameters =
			{
				new PrefabFactory.Parameter(creationData.PopupStructure, typeof(PopupStructure)),
				new PrefabFactory.Parameter(creationData.PopupContent, typeof(PopupContent))
			};
			return _prefabFactory.Create(creationData.PopupPrefab, parameters);
		}
	}
}