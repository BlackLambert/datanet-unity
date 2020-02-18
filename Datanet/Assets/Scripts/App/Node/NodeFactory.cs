using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public abstract class NodeFactory 
	{
		public NodeFactory()
		{

		}

		public abstract Node Create(Parameter parameter);

		public class Parameter
		{
			private Guid _id;
			public Guid ID { get { return _id; } }

			private Guid _templateID;
			public Guid TemplateID { get { return _templateID; } }

			public Parameter()
			{
				_id = Guid.NewGuid();
				_templateID = Guid.Empty;
			}

			public Parameter(Guid templateID)
			{
				_id = Guid.NewGuid();
				_templateID = templateID;
			}

			public Parameter(Guid templateID, Guid iD)
			{
				_id = iD;
				_templateID = templateID;
			}
		}
	}
}