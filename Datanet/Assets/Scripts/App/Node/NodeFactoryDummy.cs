using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public class NodeFactoryDummy : NodeFactory
	{
		public override Node Create(Parameter parameter)
		{
			return new Node(parameter.ID, parameter.TemplateID);
		}
	}
}