using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class NodeData : MonoBehaviour
	{
		[JsonProperty]
		public Guid ID { get; }

		[JsonProperty]
		public Guid TemplateID { get; }

		[JsonProperty]
		public HashSet<Guid> Components { get; }

		public NodeData(Guid iD,
			Guid templateID,
			HashSet<Guid> components)
		{
			ID = iD;
			TemplateID = templateID;
			Components = components;
		}
	}
}