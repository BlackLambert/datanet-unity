
namespace SBaier.UI
{
	public interface ViewDisplayer<TView> where TView : View
	{
		void Display(TView view);
		void Hide(TView view);
		void Hide();
	}
}