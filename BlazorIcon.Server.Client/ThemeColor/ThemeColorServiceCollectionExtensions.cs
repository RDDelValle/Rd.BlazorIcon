namespace Rd.BlazorIcon.Server.Client.ThemeColor;

public static class ThemeColorServiceCollectionExtensions
{
    public static IServiceCollection AddThemeColor(this IServiceCollection services)
        => services.AddScoped<ThemeColorManager>();
}