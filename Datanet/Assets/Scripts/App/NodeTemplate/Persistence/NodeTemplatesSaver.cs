﻿using SBaier.Persistence;
using SBaier.Storage;

namespace SBaier.Datanet.Core
{
	public class NodeTemplatesSaver : RepositorySaver<NodeTemplates>
	{
		public NodeTemplatesSaver(Repository<NodeTemplates> repository,
			DataPreserver<NodeTemplates> preserver) : base(repository, preserver)
		{
		}
	}
}