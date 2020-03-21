using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SBaier.Persistence
{
	public abstract class ToCollectiveDataSaverAdder<TData> : MonoBehaviour
	{
		private CollectiveDataSaver _collectiveDataSaver;
		private DataSaver<TData> _dataSaver;

		[Inject]
		private void Construct(CollectiveDataSaver collectiveDataSaver,
			DataSaver<TData> dataSaver)
		{
			_collectiveDataSaver = collectiveDataSaver;
			_dataSaver = dataSaver;
			
		}

		protected virtual void Start()
		{
			_collectiveDataSaver.Add(_dataSaver);
		}

		protected virtual void OnDestroy()
		{
			_collectiveDataSaver.Remove(_dataSaver);
		}
	}
}