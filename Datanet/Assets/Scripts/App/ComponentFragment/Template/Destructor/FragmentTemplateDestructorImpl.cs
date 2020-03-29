using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateDestructorImpl : FragmentTemplateDestructor
	{
		private ComponentFragmentTemplatesRepository _repository;
		public ComponentFragmentTemplates Templates { get { return _repository.Get(); } }

		[Inject]
		private void Construct(ComponentFragmentTemplatesRepository repository)
		{
			_repository = repository;
		}

		public override void Destruct(ComponentFragmentTemplate template)
		{
			if (Templates == null)
				throw new InvalidOperationException($"Failed to destruct {nameof(ComponentFragmentTemplate)}. " +
					$"The {nameof(ComponentFragmentTemplates)} have not been loaded yet.");
			if (template == null)
				throw new ArgumentNullException($"Failed to destruct {nameof(ComponentFragmentTemplate)}. " +
					$"The provided parameter is null.");
			Templates.Remove(template.ID);

		}
	}
}