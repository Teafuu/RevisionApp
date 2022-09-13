using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class TopicsPage : ContentPage
{
	public TopicsPage(TopicsViewModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}