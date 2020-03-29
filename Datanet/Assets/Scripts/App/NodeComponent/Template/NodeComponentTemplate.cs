

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SBaier.Datanet
{
	[JsonObject(MemberSerialization.OptIn)]
	public class NodeComponentTemplate
	{
		[JsonProperty]
		public Guid ID
		{
			get;
			private set;
		}

		[JsonProperty]
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				string former = _name;
				_name = value;
				OnNameChanged?.Invoke(this, former, _name);
			}
		}

		public event OnPropertyChangedAction<NodeComponentTemplate, string> OnNameChanged;

		[JsonProperty]
		private List<Guid> _fragmentTemplateIDs;
		public List<Guid> FragmentTemplateIDsCopy { get { return new List<Guid>( _fragmentTemplateIDs); } }

		public OnCollectionChangedAction<NodeComponentTemplate, Guid> OnFragmentTemplateAdded;
		public OnCollectionChangedAction<NodeComponentTemplate, Guid> OnFragmentTempalteRemoved;

		public NodeComponentTemplate(Guid id, string name, List<Guid> fragmentTemplateIds)
		{
			ID = id;
			Name = name;
			_fragmentTemplateIDs = fragmentTemplateIds;
		}

		public void AddFragmentTemplate(Guid fragmentToAdd)
		{
			if (fragmentToAdd == Guid.Empty)
				throw new ArgumentNullException($"Failed to add fragment template. The Guid is empty");
			if (_fragmentTemplateIDs.Contains(fragmentToAdd))
				throw new ArgumentException($"Failed to add fragment template. It has already been added before");

			_fragmentTemplateIDs.Add(fragmentToAdd);
			OnFragmentTemplateAdded?.Invoke(this, fragmentToAdd);
		}

		public void RemoveFragmentTemplate(Guid fragmentToRemove)
		{
			if (fragmentToRemove == Guid.Empty)
				throw new ArgumentNullException($"Failed to remove fragment template. The Guid is empty");
			if (!_fragmentTemplateIDs.Contains(fragmentToRemove))
				throw new ArgumentException($"Failed to remove fragment template. It has not been added before.");

			_fragmentTemplateIDs.Remove(fragmentToRemove);
			OnFragmentTempalteRemoved?.Invoke(this, fragmentToRemove);
		}
	}
}