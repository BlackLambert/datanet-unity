

namespace SBaier.Datanet.Core
{
	public abstract class DataNetFactory
	{
		public abstract DataNet Create(Parameter parameter);

		public class Parameter
		{
			public string NetName { get; private set; }

			public Parameter(string netName)
			{
				NetName = netName;
			}
		}
	}
}