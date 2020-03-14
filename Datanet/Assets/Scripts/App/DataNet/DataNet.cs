

using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public class DataNet
	{
		public Guid ID
		{
			get;
			private set;
		}

		private string _name = "";
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnNameChanged?.Invoke();
			}
		}
		public event Action OnNameChanged;

		private HashSet<Guid> _nodeIds;
		public Action<Guid> OnNodeIDAdded;
		public Action<Guid> OnNodeIDRemoved;

		public int Count { get { return _nodeIds.Count; } }


		public DataNet(Guid iD, 
			string name)
		{
			ID = iD;
			Name = name;
			_nodeIds = new HashSet<Guid>();
		}

		public void AddNode(Node value)
		{
			_nodeIds.Add(value.ID);
			OnNodeIDAdded?.Invoke(value.ID);
		}

		public void RemoveNode(Guid iD)
		{
			_nodeIds.Remove(iD);
			OnNodeIDRemoved?.Invoke(iD);
		}


		public HashSet<Guid> GetNodeIDsCopy()
		{
			return new HashSet<Guid>(_nodeIds);
		}
	}
}