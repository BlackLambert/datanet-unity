using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Popup
{
	public class PopupFactoryDummy : PopupFactory
	{
		public override PopupInstaller Create(PopupCreationData creationData)
		{
			throw new System.NotImplementedException();
		}
	}
}