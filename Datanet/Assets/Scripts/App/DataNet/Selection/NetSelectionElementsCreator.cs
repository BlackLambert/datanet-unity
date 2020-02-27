

using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;
using SBaier.UI.List;

namespace SBaier.Datanet
{
	public class NetSelectionElementsCreator: ListElementsCreator<KeyValuePair<Guid, DataNet>, NetSelectionElementInstaller>
	{
		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<Guid, DataNet> pair)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(pair.Value) };
		}
	}
}