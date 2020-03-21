
using UnityEngine;
using Zenject;

namespace SBaier.Persistence
{
	public abstract class OnStartDataLoader<TData> : MonoBehaviour
	{
		private DataLoader<TData> _dataLoader;

		[Inject]
		private void Construct(DataLoader<TData> dataLoader)
		{
			_dataLoader = dataLoader;
		}

		void Start()
		{
			_dataLoader.Load();
		}
	}
}