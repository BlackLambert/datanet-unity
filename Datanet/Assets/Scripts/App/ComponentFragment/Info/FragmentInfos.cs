using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{ 
	public class FragmentInfos : BasicDictionaryData<ComponentFragmentType, FragmentInfo>
	{
		public void Add(FragmentInfo info)
		{
			Add(info.Type, info);
		}
	}
}