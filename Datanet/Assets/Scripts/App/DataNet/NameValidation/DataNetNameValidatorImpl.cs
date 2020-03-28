

using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class DataNetNameValidatorImpl : DataNetNameValidator
	{
		public override void Validate(string name, IEnumerable<DataNet> existingNets)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("Please choose a name for the new data net!");
			foreach (DataNet net in existingNets)
			{
				if (net.Name.Equals(name))
					throw new ArgumentException($"There already is a data net with name '{name}'");
			}
		}
	}
}