
using System.Threading.Tasks;

namespace SBaier.Persistence
{
	public interface DataSaver
	{
		Task Save();
	}

	public interface DataSaver<TData> : DataSaver
	{

	}
}