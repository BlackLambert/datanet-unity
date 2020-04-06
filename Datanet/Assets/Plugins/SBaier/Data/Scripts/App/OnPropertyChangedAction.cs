
namespace SBaier
{
	public delegate void OnPropertyChangedAction<TCaller, TValue>(TCaller caller, TValue former, TValue current);
}