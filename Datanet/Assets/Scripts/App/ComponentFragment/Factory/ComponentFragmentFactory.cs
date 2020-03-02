using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public abstract class ComponentFragmentFactory 
	{
		public abstract ComponentFragment Create(ComponentFragmentTemplate template);
	}
}