

using System;
using Zenject;

namespace SBaier.Datanet.Core
{
	public class DataNetFactoryImpl : DataNetFactory
	{
		private DataNetsRepository _dataNetsRepository;
		private DataNetNameValidator _nameValidator;

		public DataNetFactoryImpl(DataNetsRepository dataNetsRepository,
			DataNetNameValidator nameValidator)
		{
			_dataNetsRepository = dataNetsRepository;
			_nameValidator = nameValidator;
		}

		public override DataNet Create(Parameter parameter)
		{
			_nameValidator.Validate(parameter.NetName, _dataNetsRepository.Copy().Values);
			NodeContainer nodeContainer = new NodeContainerImpl();
			return new DataNet(parameter.ID, nodeContainer, parameter.NetName);
		}
	}
}