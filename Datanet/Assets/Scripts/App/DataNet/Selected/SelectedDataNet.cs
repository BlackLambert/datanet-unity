

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
				DataNet former = _selected;
				_selected = value;
				OnSelectedChanged?.Invoke(former, _selected);
			}
		}
		public event OnSelectedNetChangedAction OnSelectedChanged;

		public SelectedDataNet()
		{

		}

		public delegate void OnSelectedNetChangedAction(DataNet formerNet, DataNet newNet);
	}
}