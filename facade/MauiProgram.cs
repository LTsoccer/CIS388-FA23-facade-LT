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
				fonts.AddFont("Mooli-Regular.ttf", "Mooli");
				
            });

		builder.Services.AddTransient<GameOverPage>();

#if DEBUG
		builder.Logging.AddDebug();
		
#endif

		return builder.Build();
	}
}

