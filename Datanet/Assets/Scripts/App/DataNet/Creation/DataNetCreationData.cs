

using System;

namespace SBaier.Datanet
{
	public class DataNetCreationData
	{
		private string _name = string.Empty;
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


		private string _error = string.Empty;
		public string Error
		{
			get { return _error; }
			set
			{
				_error = value;
				OnErrorChanged?.Invoke();
			}
		}
		public event Action OnErrorChanged;
	}
}