using Microsoft.Extensions.Logging;

namespace facade;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Mooli-Regular.ttf", "MooliRegular");
				
            });

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();

        builder.Services.AddTransient<GameOverPage>();
        builder.Services.AddTransient<GameOverPageViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
		
#endif

		return builder.Build();
	}
}

