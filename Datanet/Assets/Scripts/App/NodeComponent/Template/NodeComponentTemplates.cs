using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	public class NodeComponentTemplates : BasicDictionaryData<Guid, NodeComponentTemplate>
	{
		public void Add(NodeComponentTemplate template)
		{
			Add(template.ID, template);
		}
	}
}