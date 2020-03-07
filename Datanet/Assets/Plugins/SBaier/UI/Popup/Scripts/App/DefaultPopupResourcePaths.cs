using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.UI.Popup
{
	public class DefaultPopupResourcePaths : PopupResourcePaths
	{
		public override string PopupBase => "Prefabs/PopupBase";
		public override string ClosablePopupStructure => "Prefabs/ClosablePopupStructure";
		public override string SubmitPopupStructure => "Prefabs/SubmitPopupStructure";
	}
}