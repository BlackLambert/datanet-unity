using System;

namespace SBaier.Datanet
{
	public interface NodeFactory 
	{
		Node CreateByData(Guid dataID);
		Node CreateByTempalte(Guid templateID);
	}
}