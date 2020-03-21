using System.Threading.Tasks;

namespace SBaier.Persistence
{
	public interface DataLoader
	{
		Task Load();
	}

	public interface DataLoader<TData> : DataLoader
	{

	}
}