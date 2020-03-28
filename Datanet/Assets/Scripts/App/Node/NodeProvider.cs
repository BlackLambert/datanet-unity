using SBaier.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeProvider 
	{
		private Repository<Nodes> _nodesRepository;
		public Nodes Nodes { get { return _nodesRepository.Get(); } }
		private NodeFactory _nodeFactory;

		[Inject]
		private void Construct(
			Repository<Nodes> nodesRepository,
			NodeFactory nodeFactory)
		{
			_nodesRepository = nodesRepository;
			_nodeFactory = nodeFactory;
		}

		public Node Get(Guid nodeID)
		{
			checkFragmentsLoaded();
			if (Nodes.Contains(nodeID))
				return Nodes.Get(nodeID);
			return _nodeFactory.CreateByData(nodeID);
		}

		private void checkFragmentsLoaded()
		{
			if (Nodes == null)
				throw new InvalidOperationException($"Failed to create {nameof(Node)}. The {nameof(Nodes)} have not been loaded yet.");
		}
	}
}