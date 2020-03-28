using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class NodeComponentTemplateFactoryImpl : NodeComponentTemplateFactory
	{
		private const string _defaultName = "My new Component";

		public NodeComponentTemplate Create()
		{
			return new NodeComponentTemplate(Guid.NewGuid(), _defaultName, new List<Guid>());
		}
	}
}