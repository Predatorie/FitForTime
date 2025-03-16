namespace FitForTime.Services;

public static class ServiceProvider
{
    private static IServiceProvider Current
        =>
#if WINDOWS10_0_17763_0_OR_GREATER
            MauiWinUIApplication.Current.Services;
#elif ANDROID
            IPlatformApplication.Current.Services;
#elif IOS || MACCATALYST
            IPlatformApplication.Current.Services;
#else
            null;
#endif

    public static TService GetService<TService>()
    {
        return Current.GetService<TService>();
    }
}

