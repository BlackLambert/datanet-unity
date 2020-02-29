

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

		public string Name
		{
			get;
			private set;
		}

		private HashSet<NodeComponentTemplate> _componentTemplates;


		public NodeTemplate(Guid iD, 
			string name, IEnumerable<NodeComponentTemplate> componentTemplates)
		{
			ID = iD;
			Name = name;
			_componentTemplates = new HashSet<NodeComponentTemplate>(componentTemplates);
		}
	}
}