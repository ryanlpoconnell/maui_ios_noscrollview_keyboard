using Maui.FixesAndWorkarounds;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Scroll.Controls;

#if ANDROID

#elif IOS
using Scroll.iOS.Renderers;

#endif

namespace Scroll;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCompatibility()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})

			.ConfigureMauiHandlers((handlers) =>
     {
#if ANDROID

#elif IOS
                handlers.AddHandler(typeof(KeyboardView), typeof(KeyboardViewRenderer));
#endif
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

