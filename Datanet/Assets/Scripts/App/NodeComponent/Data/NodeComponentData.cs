using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class NodeComponentData
	{
		[JsonProperty]
		public Guid ID { get; }

		[JsonProperty]
		public Guid TemplateID { get; }

		[JsonProperty]
		public HashSet<Guid> Fragments { get; }

		public NodeComponentData(Guid iD,
			Guid templateID,
			HashSet<Guid> fragmentIDs)
		{
			ID = iD;
			TemplateID = templateID;
			Fragments = fragmentIDs;
		}
	}
}