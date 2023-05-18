using Maui.FixesAndWorkarounds;
using Microsoft.Extensions.Logging;

namespace Scroll;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        //https://github.com/PureWeen/ShanedlerSamples
		//Added to fix iOS ScrollView with Keyboard not working until .Net 8
		//but other fixes exist as per the pick some section.
        //builder.ConfigureMauiWorkarounds(); //configures all know workarounds
		//Pick some...
//        builder.ConfigureShellWorkarounds();
//        builder.ConfigureTabbedPageWorkarounds();
//        builder.ConfigureEntryNextWorkaround();
//        builder.ConfigureKeyboardAutoScroll();
//        builder.ConfigureFlyoutPageWorkarounds();

//#if ANDROID
//        builder.ConfigureEntryFocusOpensKeyboard();
//#endif

        return builder.Build();
	}
}

