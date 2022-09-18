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

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<LoginViewModel>();

		builder.Services.AddTransient<CreateAccountPage>();
		builder.Services.AddTransient<CreateAccountViewModel>();

        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomeViewModel>();

        builder.Services.AddTransient<TopicsPage>();
        builder.Services.AddTransient<TopicsViewModel>();

        builder.Services.AddHttpClient<RevisionService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7142");
        });

        builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
	