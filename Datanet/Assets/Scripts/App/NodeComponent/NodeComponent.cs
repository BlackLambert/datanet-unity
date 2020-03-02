using System;
using System.Collections.Generic;

namespace SBaier.Datanet.Core
{
	public abstract class NodeComponent
	{
		public Guid ID
		{
			get;
			private set;
		}

		private HashSet<ComponentFragment> _fragments;
		public HashSet<ComponentFragment> FragmentsCopy { get { return new HashSet<ComponentFragment>(_fragments); } }


		public NodeComponent(Guid iD, HashSet<ComponentFragment> fragments)
		{
			ID = iD;
			_fragments = fragments;
		}


		public void AddFragment(ComponentFragment fragmentToAdd)
		{
			_fragments.Add(fragmentToAdd);
		}

		public void RemoveFragment(ComponentFragment fragmentToRemove)
		{
			_fragments.Remove(fragmentToRemove);
		}
	}
}