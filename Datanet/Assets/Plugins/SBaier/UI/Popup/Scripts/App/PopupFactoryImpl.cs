using System;
using System.Collections.Generic;
using System.Linq;
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
			validateParameters(creationData);
			PrefabFactory.Parameter[] parameters = createParameters(creationData);
			return _prefabFactory.Create(creationData.PopupPrefab, parameters);
		}

		private void validateParameters(PopupCreationData creationData)
		{
			if (creationData == null)
				throw new ArgumentNullException();
			if (creationData.PopupPrefab == null)
				throw new ArgumentNullException();
		}

		private PrefabFactory.Parameter[] createParameters(PopupCreationData creationData)
		{
			List<PrefabFactory.Parameter> result = new List<PrefabFactory.Parameter>();
			if(creationData.PopupStructure != null)
				result.Add(new PrefabFactory.Parameter(creationData.PopupStructure));
			if(creationData.PopupContent != null)
				result.Add(new PrefabFactory.Parameter(creationData.PopupContent));
			return result.ToArray();
		}
	}
}