

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class NodeTemplate
	{
		public Guid ID
		{
			get;
			private set;
		}

		private HashSet<NodeComponentTemplate> _componentTemplates;


		public NodeTemplate(Guid iD, IEnumerable<NodeComponentTemplate> componentTemplates)
		{
			ID = iD;
			_componentTemplates = new HashSet<NodeComponentTemplate>(componentTemplates);
		}
	}
}