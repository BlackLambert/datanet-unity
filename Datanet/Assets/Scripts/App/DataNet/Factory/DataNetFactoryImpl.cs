﻿

using System;
using Zenject;

namespace SBaier.Datanet
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
			_nameValidator.Validate(parameter.NetName, _dataNetsRepository.Get().CopyDictionary().Values);
			return new DataNet(parameter.ID, parameter.NetName);
		}
	}
}