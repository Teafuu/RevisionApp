using RevisionApp.ViewModels.Views;

namespace RevisionApp.Views;

public partial class TopicView : ContentView
{
	public TopicView(TopicViewModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}