

using System;

namespace SBaier.Datanet
{
	public abstract class DataNetFactory
	{
		public abstract DataNet Create(Parameter parameter);

		public class Parameter
		{
			public Guid ID { get; private set; }
			public string NetName { get; private set; }

			public Parameter(
				string netName)
			{
				ID = Guid.NewGuid();
				NetName = netName;
			}

			public Parameter(
				Guid id,
				string netName)
			{
				ID = id;
				NetName = netName;
			}
		}
	}
}