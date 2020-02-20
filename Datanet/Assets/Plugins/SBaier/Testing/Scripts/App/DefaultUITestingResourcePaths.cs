using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SBaier.Testing.UI
{
	public class DefaultUITestingResourcePaths : UITestResourcePaths
	{
		public override string HightMatchingCanvasPath => "Prefabs/HightMatchingTestCanvas";

		public override string TestCameraPath => "Prefabs/UITestCamera";
	}
}