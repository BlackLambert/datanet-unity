using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SBaier.Popup;

namespace SBaier.Datanet
{
	public class DataNetPopupResourcePaths : PopupResourcePaths
	{
		public override string PopupBase => "Prefabs/Popup/PopupBase";

		public override string ClosablePopupStructure => "Prefabs/Popup/ClosablePopupStructure";

		public override string SubmitPopupStructure => "Prefabs/Popup/SubmitPopupStructure";
	}
}
