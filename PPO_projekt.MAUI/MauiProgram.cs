using PPO_projekt.Application.Services;
using PPO_projekt.MAUI.ViewModels;
using PPO_projekt.MAUI.Views;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<SchoolService>();

        builder.Services.AddTransient<MainViewModel>();

        builder.Services.AddTransient<MainPage>();

        return builder.Build();
    }
}