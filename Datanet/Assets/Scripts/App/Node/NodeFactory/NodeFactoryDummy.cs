
using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class NodeFactoryDummy : NodeFactory
	{
		public Node CreateByData(Guid dataID)
		{
			Guid templateID = Guid.NewGuid();
			return new Node(new NodeData(dataID, templateID, new HashSet<Guid>()),
				new NodeTemplate(templateID, "Bla", new List<Guid>()));
		}

		public Node CreateByTempalte(Guid templateID)
		{
			Guid dataID = Guid.NewGuid();
			return new Node(new NodeData(dataID, templateID, new HashSet<Guid>()),
				new NodeTemplate(templateID, "Bla", new List<Guid>()));
		}
	}
}