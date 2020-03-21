using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace SBaier.Persistence
{
	public interface DataPreserver<TData> 
	{
		Task Preserve(TData data);
		Task<TData> Retrieve();
	}
}