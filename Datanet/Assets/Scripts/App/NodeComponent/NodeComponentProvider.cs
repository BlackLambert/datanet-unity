using SBaier.Storage;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeComponentProvider
	{
		private Repository<NodeComponents> _componentsRepository;
		public NodeComponents Components { get { return _componentsRepository.Get(); } }
		private NodeComponentFactory _nodeFactory;

		[Inject]
		private void Construct(
			Repository<NodeComponents> componentsRepository,
			NodeComponentFactory componentsFactory)
		{
			_componentsRepository = componentsRepository;
			_nodeFactory = componentsFactory;
		}

		public NodeComponent Get(Guid componentID)
		{
			checkFragmentsLoaded();
			if (Components.Contains(componentID))
				return Components.Get(componentID);
			return _nodeFactory.CreateByData(componentID);
		}

		private void checkFragmentsLoaded()
		{
			if (Components == null)
				throw new InvalidOperationException($"Failed to create {nameof(NodeComponent)}. The {nameof(NodeComponents)} have not been loaded yet.");
		}
	}
}