using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SBaier.UI.List;
using System;

namespace SBaier.Datanet
{
	public class PossibleFragmentsListElementsCreator : ListElementsCreator<FragmentInfos, KeyValuePair<ComponentFragmentType, FragmentInfo>, FragmentSelectionListElementInstaller>
	{
		protected override PrefabFactory.Parameter[] getPrefabFactoryParameters(KeyValuePair<ComponentFragmentType, FragmentInfo> data)
		{
			return new PrefabFactory.Parameter[] {new PrefabFactory.Parameter(data.Value) };
		}
	}
}