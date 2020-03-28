using SBaier.UI.List;
using SBaier.Datanet;
using System.Collections.Generic;
using System;

namespace SBaier.Datanet
{
	public class NodeTemplateSelectionElementCreator : ListElementsCreator<NodeTemplates, KeyValuePair<Guid,NodeTemplate>, SelectNodeTemplateElementInstaller>
	{
		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<Guid, NodeTemplate> data)
		{
			return new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(data.Value) };
		}
	}
}