using System;

namespace SBaier.Datanet
{
	public interface NodeComponentFactory 
	{
		NodeComponent CreateByData(Guid dataID);
		NodeComponent CreateByTemplate(Guid templateID);
	}
}