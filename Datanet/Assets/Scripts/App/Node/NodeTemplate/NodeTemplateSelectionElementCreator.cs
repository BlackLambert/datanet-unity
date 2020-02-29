using SBaier.UI.List;
using SBaier.Datanet.Core;
using System.Collections.Generic;
using System;

namespace SBaier.Datanet
{
	public class NodeTemplateSelectionElementCreator : ListElementsCreator<KeyValuePair<Guid,NodeTemplate>, SelectNodeTemplateElementInstaller>
	{
		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<Guid, NodeTemplate> data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data.Value) };
		}
	}
}