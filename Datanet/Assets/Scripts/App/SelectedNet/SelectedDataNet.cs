

using SBaier.Datanet.Core;
using System;

namespace SBaier.Datanet
{
	public class SelectedDataNet
	{
		private DataNet _selected = null;
		public DataNet Selected
		{
			get { return _selected; }
			set
			{
				_selected = value;
				OnSelectedChanged?.Invoke();
			}
		}
		public event Action OnSelectedChanged;

		public SelectedDataNet()
		{

		}
	}
}