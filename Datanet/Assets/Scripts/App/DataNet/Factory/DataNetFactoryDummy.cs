

namespace SBaier.Datanet.Core
{
	public class DataNetFactoryDummy : DataNetFactory
	{
		public override DataNet Create(Parameter parameter)
		{
			return new DataNet(parameter.ID, parameter.NetName);
		}
	}
}