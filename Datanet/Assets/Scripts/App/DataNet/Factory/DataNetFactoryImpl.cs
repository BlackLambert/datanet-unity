

using System;
using Zenject;

namespace SBaier.Datanet.Core
{
	public class DataNetFactoryImpl : DataNetFactory
	{
		private DataNetContainer _dataNetContainer;
		private DataNetNameValidator _nameValidator;

		public DataNetFactoryImpl(DataNetContainer dataNetContainer,
			DataNetNameValidator nameValidator)
		{
			_dataNetContainer = dataNetContainer;
			_nameValidator = nameValidator;
		}

		public override DataNet Create(Parameter parameter)
		{
			_nameValidator.Validate(parameter.NetName, _dataNetContainer.DataNetsCopy);
			NodeContainer nodeContainer = new NodeContainerImpl();
			return new DataNet(parameter.ID, nodeContainer, parameter.NetName);
		}
	}
}