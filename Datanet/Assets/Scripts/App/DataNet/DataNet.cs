﻿

using System;

namespace SBaier.Datanet.Core
{
	public class DataNet
	{
		public Guid ID
		{
			get;
			private set;
		}

		public NodeContainer NodeContainer
		{
			get;
			private set;
		}

		private string _name = "";
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnNameChanged?.Invoke();
			}
		}
		public event Action OnNameChanged;


		public DataNet(Guid iD, 
			NodeContainer nodeContainer,
			string name)
		{
			ID = iD;
			NodeContainer = nodeContainer;
			Name = name;
		}
	}
}