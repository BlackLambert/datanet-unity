using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using SBaier.Storage;

namespace SBaier.UI.List
{
	public abstract class ListElementsCreator<TData, TElement> : MonoBehaviour where TElement : Component
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

		private ICollectionRepository<TData> _repository;
		private PrefabFactory _prefabFactory;
		private TElement _elementPrefab;

		private Dictionary<TData, TElement> _elements;
		public Dictionary<TData, TElement> ElementsCopy { get { return new Dictionary<TData, TElement>(_elements); } }

		[Inject]
		private void Construct(ICollectionRepository<TData> repository,
			PrefabFactory prefabFactory,
			TElement elementPrefab)
		{
			_repository = repository;
			_prefabFactory = prefabFactory;
			_elementPrefab = elementPrefab;
		}

		protected virtual void Start()
		{
			_repository.OnCollectionContentAdded += onContentAdded;
			_repository.OnCollectionContentRemoved += onContentRemoved;
			initElements();
		}

		protected virtual void OnDestroy()
		{
			_repository.OnCollectionContentAdded -= onContentAdded;
			_repository.OnCollectionContentRemoved -= onContentRemoved;
		}

		private void initElements()
		{
			_elements = new Dictionary<TData, TElement>();
			foreach (TData data in _repository.Get())
				addElement(data);
		}

		private void onContentAdded(TData addedData)
		{
			addElement(addedData);
		}

		private void onContentRemoved(TData removedNet)
		{
			TElement elementToRemove = _elements[removedNet];
			_elements.Remove(removedNet);
			Destroy(elementToRemove.gameObject);
		}

		private void addElement(TData data)
		{
			PrefabFactory.Parameter[] parameters = getPrefabFactoryParameters(data);
			TElement createdElement = _prefabFactory.Create(_elementPrefab, parameters);
			createdElement.transform.SetParent(_hook, false);
			_elements.Add(data, createdElement);
		}

		protected abstract PrefabFactory.Parameter[] getPrefabFactoryParameters(TData data);
	}
}