using RevisionApp.ViewModels;

namespace RevisionApp.Pages;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage(CreateAccountViewModel model)
	{
		BindingContext = model;
		InitializeComponent();
	}
	
}