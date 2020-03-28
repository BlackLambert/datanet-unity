

namespace SBaier.Datanet
{
	public class DataNetFactoryDummy : DataNetFactory
	{
		public override DataNet Create(Parameter parameter)
		{
			return new DataNet(parameter.ID, parameter.NetName);
		}
	}
}