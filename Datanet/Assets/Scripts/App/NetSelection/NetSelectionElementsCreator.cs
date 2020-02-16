

using SBaier.Datanet.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Datanet
{
	public class NetSelectionElementsCreator: MonoBehaviour
	{
		[SerializeField]
		private Transform _hook = null;
		public Transform Hook { get { return _hook; } }

		private DataNetContainer _dataNetContainer;
		private PrefabFactory _prefabFactory;
		private NetSelectionElementInstaller _elementPrefab;

		private Dictionary<Guid, NetSelectionElementInstaller> _elements;
		public Dictionary<Guid, NetSelectionElementInstaller> ElementsCopy { get { return new Dictionary<Guid, NetSelectionElementInstaller>(_elements); } }

		[Inject]
		private void Construct(DataNetContainer dataNetContainer,
			PrefabFactory prefabFactory,
			NetSelectionElementInstaller elementPrefab)
		{
			_dataNetContainer = dataNetContainer;
			_prefabFactory = prefabFactory;
			_elementPrefab = elementPrefab;
		}

		protected virtual void Start()
		{
			_dataNetContainer.OnNetAdded += onDataNetAdded;
			_dataNetContainer.OnNetRemoved += onDataNetRemoved;
			initElements();
		}

		protected virtual void OnDestroy()
		{
			_dataNetContainer.OnNetAdded -= onDataNetAdded;
			_dataNetContainer.OnNetRemoved -= onDataNetRemoved;
		}

		private void initElements()
		{
			_elements = new Dictionary<Guid, NetSelectionElementInstaller>();
			foreach (DataNet net in _dataNetContainer.DataNetsCopy)
				addElement(net);
		}

		private void onDataNetAdded(DataNet addedNet)
		{
			addElement(addedNet);
		}

		private void onDataNetRemoved(DataNet removedNet)
		{
			NetSelectionElementInstaller elementToRemove = _elements[removedNet.ID];
			_elements.Remove(removedNet.ID);
			Destroy(elementToRemove.gameObject);
		}

		private void addElement(DataNet net)
		{
			PrefabFactory.Parameter[] parameters = { new PrefabFactory.Parameter( net, typeof(DataNet) ) };
			NetSelectionElementInstaller createdElement = _prefabFactory.Create(_elementPrefab, parameters);
			createdElement.transform.SetParent(_hook, false);
			_elements.Add(net.ID, createdElement);
		}
	}
}