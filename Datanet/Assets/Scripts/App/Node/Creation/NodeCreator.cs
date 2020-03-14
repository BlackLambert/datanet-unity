using SBaier.Datanet.Core;
using System;
using UnityEngine;

namespace SBaier.Datanet
{
	public abstract class NodeCreator : MonoBehaviour
	{
		public abstract event Action<Node> OnNodeCreated;
	}
}