

using System;

namespace SBaier.Datanet.Core
{
	public class DataNetFactoryImpl : DataNetFactory
	{
		public override DataNet Create(Parameter parameter)
		{
			

			NodeContainer nodeContainer = new NodeContainer();
			Guid id = Guid.NewGuid();
			return new DataNet(id, nodeContainer, parameter.NetName);
		}
	}
}