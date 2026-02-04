using Microsoft.Extensions.Logging;
using MeuSite.Shared.Contracts;
using MeuSite.Services;
using MeuSite.Ui.ViewModels;

namespace MeuSite;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<IResumeDataProvider, ResumeDataProvider>();
        builder.Services.AddScoped<ResumePageViewModel>();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
