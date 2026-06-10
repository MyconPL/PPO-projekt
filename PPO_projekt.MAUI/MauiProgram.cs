using PPO_projekt.Application.Services;
using PPO_projekt.MAUI.ViewModels;

// dodaj usingi do swojego widoku i viewmodelu, np:
// using PPO_projekt.MAUI.Views;
// using PPO_projekt.MAUI.ViewModels;

namespace PPO_projekt.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold", "OpenSansSemibold");
            });

        // Rejestracja zależności
        builder.Services.AddSingleton<SchoolService>();
        builder.Services.AddSingleton<SchoolViewModel>();
        builder.Services.AddSingleton<MainPage>(); // Zakładam, że używasz MainPage jako głównego okna

        return builder.Build();
    }
}