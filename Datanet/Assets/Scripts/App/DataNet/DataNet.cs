

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
		}

		public void RemoveComponent(Guid iD)
		{
			_nodeIds.Remove(iD);
		}


		public HashSet<Guid> GetNodeIDsCopy()
		{
			return new HashSet<Guid>(_nodeIds);
		}
	}
}