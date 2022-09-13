using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}


}