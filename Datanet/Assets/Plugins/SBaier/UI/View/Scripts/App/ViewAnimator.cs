using System;
using UnityEngine;

namespace SBaier.UI
{
	public abstract class ViewAnimator : MonoBehaviour
	{
		[SerializeField]
		protected bool _hideOnAwake = true;

		public abstract void Display();
		public abstract void Hide();
		public abstract event Action OnHidden;
	}
}