using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SBaier.Persistence
{
	public interface DataSaver
	{
		Task Save();
	}

	public interface DataSaver<TData> : DataSaver
	{

	}
}