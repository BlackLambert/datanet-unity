using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	public class NodeComponent
	{
		public NodeComponentTemplate Template { get; private set; }
		public NodeComponentData Data { get; private set; }
		public Guid ID { get { return Data.ID; } }
		public string Name { get { return Template.Name; } }
		public HashSet<Guid> FragmentsCopy { get { return new HashSet<Guid>(Data.Fragments); } }




		public NodeComponent(NodeComponentTemplate template, NodeComponentData data)
		{
			Data = data;
			Template = template;
		}


		public void AddFragment(Guid fragmentToAdd)
		{
			if (fragmentToAdd == Guid.Empty)
				throw new ArgumentNullException($"Failed to add fragment. The Guid is empty");
			if (Data.Fragments.Contains(fragmentToAdd))
				throw new ArgumentException($"Failed to add fragment. It has already been added before");

			Data.Fragments.Add(fragmentToAdd);
		}

		public void RemoveFragment(Guid fragmentToRemove)
		{
			if (fragmentToRemove == Guid.Empty)
				throw new ArgumentNullException($"Failed to remove fragment. The Guid is empty");
			if (!Data.Fragments.Contains(fragmentToRemove))
				throw new ArgumentException($"Failed to remove fragment. It has not been added before.");

			Data.Fragments.Remove(fragmentToRemove);
		}
	}
}