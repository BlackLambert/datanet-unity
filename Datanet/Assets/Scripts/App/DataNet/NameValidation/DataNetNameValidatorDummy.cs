﻿

using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	public class DataNetNameValidatorDummy : DataNetNameValidator
	{
		public override void Validate(string name, IEnumerable<DataNet> existingNets)
		{
			Debug.Log("Dummy validator is validating name.");
		}
	}
}