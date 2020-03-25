

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	[Serializable]
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

		private List<Guid> _componentTemplates;
		public List<Guid> ComponentTemplatesCopy { get { return new List<Guid>( _componentTemplates); } }


		public NodeTemplate(Guid iD, 
			string name, List<Guid> componentTemplates)
		{
			ID = iD;
			Name = name;
			_componentTemplates = new List<Guid>(componentTemplates);
		}
	}
}