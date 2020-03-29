using SBaier.Storage;
using System;
using System.Collections.Generic;
using Zenject;

namespace SBaier.Datanet
{
	public class NodeComponentTemplateFactoryImpl : NodeComponentTemplateFactory
	{
		private NodeComponentTemplatesRepository _repository;
		public NodeComponentTemplates Templates { get { return _repository.Get(); } }

		[Inject]
		private void Construct(NodeComponentTemplatesRepository repository)
		{
			_repository = repository;
		}

		public NodeComponentTemplate Create()
		{
			checkTemplatesLoaded();
			NodeComponentTemplate template = new NodeComponentTemplate(Guid.NewGuid(), string.Empty, new List<Guid>());
			Templates.Add(template);
			return template;
		}

		private void checkTemplatesLoaded()
		{
			if (Templates == null)
				throw new InvalidOperationException($"Failed to create {nameof(NodeComponent)}. The {nameof(NodeComponentTemplates)} have not been loaded yet.");
		}
	}
}