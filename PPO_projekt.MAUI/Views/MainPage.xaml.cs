using Microsoft.Extensions.DependencyInjection;
using PPO_projekt.MAUI.ViewModels;

namespace PPO_projekt.MAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
        : this(App.Current?.Handler?.MauiContext?.Services?.GetRequiredService<SchoolViewModel>()
            ?? throw new InvalidOperationException("SchoolViewModel is not available."))
    {
    }

    public MainPage(SchoolViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Powiązanie widoku z logiką ViewModelu
    }
}
