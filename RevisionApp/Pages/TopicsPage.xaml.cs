using RevisionApp.Services;
using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class TopicsPage : ContentPage
{
    private TopicsViewModel _model;
	public TopicsPage(TopicsViewModel model)
	{
		BindingContext = model;
        _model = model;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _model.FillTopics();
    }
}