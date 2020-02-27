using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public interface Repository<TData>
	{
		TData Get();
		void Store(TData value);
		event RepositoryDataChangedAction<TData> OnRepositoryDataChanged;
	}
}