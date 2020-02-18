using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Popup
{
	public abstract class PopupFactory 
	{
		public abstract PopupInstaller Create(PopupCreationData creationData);
	}
}