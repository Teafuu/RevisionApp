using RevisionApp.Pages;
using RevisionApp.Services;
using RevisionApp.ViewModels;
using RevisionApp.ViewModels.Views;
using RevisionApp.Views;

namespace RevisionApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.Services.AddScoped<MainPage>();
		builder.Services.AddScoped<LoginViewModel>();

		builder.Services.AddScoped<CreateAccountPage>();
		builder.Services.AddScoped<CreateAccountViewModel>();

		builder.Services.AddScoped<TopicView>();
		builder.Services.AddScoped<TopicViewModel>();
        builder.Services.AddHttpClient<RevisionService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7142");
        });

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
	