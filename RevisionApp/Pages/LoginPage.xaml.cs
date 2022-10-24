using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(LoginViewModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
}

