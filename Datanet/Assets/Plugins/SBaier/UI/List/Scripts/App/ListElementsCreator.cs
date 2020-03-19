using System.Collections.Generic;
using UnityEngine;
using Zenject;
using SBaier.Storage;

namespace SBaier.UI.List
{
	public abstract class ListElementsCreator<TDatas, TData, TElement> : MonoBehaviour where TElement : Component where TDatas : CollectionData<TData>
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

		public TDatas Datas { get { return _repository.Get(); } }

		private Repository<TDatas> _repository;
		private PrefabFactory _prefabFactory;
		private TElement _elementPrefab;

		private Dictionary<TData, TElement> _elements;
		public Dictionary<TData, TElement> ElementsCopy { get { return new Dictionary<TData, TElement>(_elements); } }

		[Inject]
		private void Construct(Repository<TDatas> repository,
			PrefabFactory prefabFactory,
			TElement elementPrefab)
		{
			_repository = repository;
			_prefabFactory = prefabFactory;
			_elementPrefab = elementPrefab;
		}

		protected virtual void Start()
		{
			_repository.OnRepositoryDataChanged += onRepositoryContentChanged;
			if (Datas != null)
				init(Datas);
		}

		protected virtual void OnDestroy()
		{
			_repository.OnRepositoryDataChanged -= onRepositoryContentChanged;
			if (Datas != null)
				cleanUp(Datas);
		}

		private void onRepositoryContentChanged(TDatas former, TDatas newContent)
		{
			if (newContent != null)
				init(newContent);
		}

		private void init(TDatas datas)
		{
			datas.OnCollectionContentAdded += onContentAdded;
			datas.OnCollectionContentRemoved += onContentRemoved;
			initElements();
		}

		private void cleanUp(TDatas datas)
		{
			datas.OnCollectionContentAdded -= onContentAdded;
			datas.OnCollectionContentRemoved -= onContentRemoved;
			cleanUpElements();
		}

		private void onContentAdded(TData addedData)
		{
			addElement(addedData);
		}

		private void addElement(TData data)
		{
			PrefabFactory.Parameter[] parameters = getPrefabFactoryParameters(data);
			TElement createdElement = _prefabFactory.Create(_elementPrefab, parameters);
			createdElement.transform.SetParent(_hook, false);
			_elements.Add(data, createdElement);
		}

		private void onContentRemoved(TData removedNet)
		{
			TElement elementToRemove = _elements[removedNet];
			_elements.Remove(removedNet);
			Destroy(elementToRemove.gameObject);
		}

		private void initElements()
		{
			_elements = new Dictionary<TData, TElement>();
			foreach (TData data in Datas.CopyCollection())
				addElement(data);
		}

		private void cleanUpElements()
		{
			foreach(TElement element in _elements.Values)
				Destroy(element.gameObject);
			_elements.Clear();
		}

		protected abstract PrefabFactory.Parameter[] getPrefabFactoryParameters(TData data);
	}
}