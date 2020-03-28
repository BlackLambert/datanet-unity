using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class Node
	{
		public Guid ID { get { return _data.ID; } }
		public Guid TemplateID { get { return _data.TemplateID; } }
		public string Name { get { return _template.Name; } }

		private NodeData _data;
		private NodeTemplate _template;

		public OnCollectionChangedAction<Node, Guid> OnComponentIDAdded;
		public OnCollectionChangedAction<Node, Guid> OnComponentIDRemoved;

		public Node(NodeData data, NodeTemplate tempalte)
		{
			_data = data;
			_template = tempalte;
		}

		public void AddComponentID(Guid value)
		{
			if (value == default)
				throw new ArgumentNullException($"The provided {nameof(Guid)} is empty. This is not allowed.");
			if (_data.Components.Contains(value))
				throw new ArgumentNullException($"The provided {nameof(Guid)} has already been added. Adding double is not allowed.");

			_data.Components.Add(value);
			OnComponentIDAdded?.Invoke(this, value);
		}

		public void RemoveComponentID(Guid value)
		{
			if (value == default)
				throw new ArgumentNullException($"The provided {nameof(Guid)} is empty. This is not allowed.");
			if (!_data.Components.Contains(value))
				throw new ArgumentNullException($"The provided {nameof(Guid)} has not been added yet. Therefore removing it is not possible.");

			_data.Components.Remove(value);
			OnComponentIDRemoved?.Invoke(this, value);
		}

		public HashSet<Guid> GetComponentsCopy()
		{
			return new HashSet<Guid>(_data.Components);
		}

		public override string ToString()
		{
			return $"Node(ID: {ID})";
		}
	}
}