using SBaier.Datanet;
using SBaier.UI.List;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class NodesListElementsCreator : ListElementsCreator<Nodes, KeyValuePair<Guid, Node>, NodesListElementInstaller>
	{

		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<Guid, Node> data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data.Value) };
		}
	}
}