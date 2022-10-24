using CommunityToolkit.Maui;
using RevisionApp.Pages;
using RevisionApp.Services;
using RevisionApp.ViewModels;

namespace RevisionApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder
           .UseMauiApp<App>()
           .UseMauiCommunityToolkit()
           .ConfigureFonts(fonts =>
           {
               fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
               fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
           });

        //Address for Revision API
        builder.Services.AddHttpClient<RevisionService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7142");
        });

        builder.Services.AddScoped<MainPage, LoginViewModel>();

        builder.Services.AddScoped<CreateAccountPage, CreateAccountViewModel>();

        builder.Services.AddScoped<HomePage, HomeViewModel>();

        builder.Services.AddScoped<TopicsPage, TopicsViewModel>();



       

		return builder.Build();
	}
}
	