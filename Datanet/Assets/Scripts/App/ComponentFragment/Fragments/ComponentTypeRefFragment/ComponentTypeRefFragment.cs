using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet.Core
{
	public class ComponentTypeRefFragment : ComponentFragment
	{
		public Guid ComponentTypeID
		{
			get;
			private set;
		}

		public ComponentTypeRefFragment(Guid iD, Guid componentTypeID) : base(iD)
		{
			ComponentTypeID = componentTypeID;
		}
	}
}