

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class DataNetNameValidator
	{
		public void Validate(string name, IEnumerable<DataNet> existingNets)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("Please choose a name for the new data net!");
			foreach(DataNet net in existingNets)
			{
				if (net.Name.Equals(name))
					throw new ArgumentException($"There already is a data net with name '{name}'");
			}
		}
	}
}