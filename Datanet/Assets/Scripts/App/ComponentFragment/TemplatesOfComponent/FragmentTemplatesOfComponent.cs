using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplatesOfComponent : BasicListData<Guid>, IDisposable
	{
		private NodeComponentTemplate _nodeComponentTemplate;

		public FragmentTemplatesOfComponent(NodeComponentTemplate nodeComponentTemplate) :base()
		{
			_nodeComponentTemplate = nodeComponentTemplate;
			init();
		}

		public void Dispose()
		{
			_nodeComponentTemplate.OnFragmentTemplateAdded -= onAdded;
			_nodeComponentTemplate.OnFragmentTempalteRemoved -= onRemoved;
		}

		private void init()
		{
			foreach (Guid iD in _nodeComponentTemplate.FragmentTemplateIDsCopy)
				Add(iD);
			_nodeComponentTemplate.OnFragmentTemplateAdded += onAdded;
			_nodeComponentTemplate.OnFragmentTempalteRemoved += onRemoved;
		}

		private void onAdded(NodeComponentTemplate template, Guid iD)
		{
			Add(iD);
		}

		private void onRemoved(NodeComponentTemplate template, Guid iD)
		{
			Remove(iD);
		}
	}
}