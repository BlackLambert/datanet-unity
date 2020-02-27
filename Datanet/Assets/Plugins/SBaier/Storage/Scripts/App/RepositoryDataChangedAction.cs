namespace SBaier.Storage
{
	public delegate void RepositoryDataChangedAction<TData>(TData former, TData newData);
}
