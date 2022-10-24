using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _model;

    public HomePage(HomeViewModel model)
	{
		BindingContext = model;
		InitializeComponent();
        _model = model;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _model.FillTopics();
    }

}