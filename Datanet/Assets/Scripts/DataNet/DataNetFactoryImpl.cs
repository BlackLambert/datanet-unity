

using System;

namespace SBaier.Datanet.Core
{
	public class DataNetFactoryImpl : DataNetFactory
	{
		public override DataNet Create()
		{
			NodeContainer nodeContainer = new NodeContainer();
			Guid id = Guid.NewGuid();
			return new DataNet(id, nodeContainer);
		}
	}
}