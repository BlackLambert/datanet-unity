using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class Node
	{
		public Guid ID
		{
			private set;
			get;
		}

		public Guid TemplateID
		{
			private set;
			get;
		}

		private HashSet<NodeComponent> _components;

		public Node(Guid iD, Guid templateID)
		{
			ID = iD;
			TemplateID = templateID;
			_components = new HashSet<NodeComponent>();
		}

		public void AddComponent(NodeComponent value)
		{
			_components.Add(value);
		}

		public void RemoveComponent(NodeComponent value)
		{
			_components.Remove(value);
		}

		public IEnumerable<NodeComponent> GetComponentsCopy()
		{
			return new List<NodeComponent>(_components);
		}
	}
}