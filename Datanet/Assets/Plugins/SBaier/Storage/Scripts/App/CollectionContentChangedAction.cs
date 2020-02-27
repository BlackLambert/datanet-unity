using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Storage
{
	public delegate void CollectionContentChangedAction<TContent>(TContent content);
}