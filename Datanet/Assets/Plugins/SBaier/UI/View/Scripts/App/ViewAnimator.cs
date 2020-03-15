using System;
using UnityEngine;

namespace SBaier.UI
{
	public abstract class ViewAnimator : MonoBehaviour
	{
		

		public abstract void Display();
		public abstract void Hide();
		public abstract void HideImmediatly();
		public abstract event Action OnHidden;
	}
}