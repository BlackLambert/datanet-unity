

using SBaier.Datanet;
using System;
using System.Collections.Generic;
using SBaier.UI.List;

namespace SBaier.Datanet
{
	public class NetSelectionElementsCreator: ListElementsCreator<DataNets, KeyValuePair<Guid, DataNet> , NetSelectionElementInstaller>
	{

		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<Guid, DataNet> data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data.Value) };
		}
	}
}