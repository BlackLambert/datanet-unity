

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	[Serializable]
	public class NodeComponentTemplate
	{
		public Guid ID
		{
			get;
			private set;
		}

		private List<Guid> _fragmentTemplateIDs;
		public List<Guid> FragmentTemplateIDsCopy { get { return new List<Guid>( _fragmentTemplateIDs); } }

		public NodeComponentTemplate(Guid id, List<Guid> fragmentTemplateIds)
		{
			ID = id;
			_fragmentTemplateIDs = fragmentTemplateIds;
		}
	}
}