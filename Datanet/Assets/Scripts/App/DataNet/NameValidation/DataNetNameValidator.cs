

using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public abstract class DataNetNameValidator
	{
		public abstract void Validate(string name, IEnumerable<DataNet> existingNets);
	}
}