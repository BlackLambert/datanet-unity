using System;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class FragmentTemplateListElementContentCreator : MonoBehaviour
	{
		private ComponentFragmentTemplate _template;
		private PrefabFactory _prefabFactory;

		[SerializeField]
		private Transform _hook = null;

		[Inject]
		private void Construct(ComponentFragmentTemplate template,
			PrefabFactory prefabFactory)
		{
			_template = template;
			_prefabFactory = prefabFactory;
		}


		protected virtual void Start()
		{
			addContent();
		}

		private void addContent()
		{
			FragmentTemplateListElementContentInstaller content = create();
			content.Base.transform.SetParent(_hook, false);
		}

		private FragmentTemplateListElementContentInstaller create()
		{
			if (_template is TextFragmentTemplate)
				return instantiate(ResourcePaths.TextFragmentTemplateListElementContent, typeof(TextFragmentTemplate));
			throw new NotImplementedException($"The visual representation of the type {_template.GetType()} has not been implemented yet.");
		}

		private FragmentTemplateListElementContentInstaller instantiate(string path, Type templateType)
		{
			FragmentTemplateListElementContentInstaller prefab = Resources.Load<FragmentTemplateListElementContentInstaller>(path);
			return _prefabFactory.Create(prefab, new PrefabFactory.Parameter[] { new PrefabFactory.Parameter(_template, templateType) });
		}
	}
}