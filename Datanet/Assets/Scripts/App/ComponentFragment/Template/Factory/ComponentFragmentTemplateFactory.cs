using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	public abstract class ComponentFragmentTemplateFactory 
	{
		public abstract ComponentFragmentTemplate Create(ComponentFragmentType type);

	}
}