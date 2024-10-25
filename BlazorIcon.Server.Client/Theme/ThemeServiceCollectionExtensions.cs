namespace Rd.BlazorIcon.Server.Client.Theme;

public static class ThemeServiceCollectionExtensions
{
    public static IServiceCollection AddTheme(this IServiceCollection services)
        => services.AddScoped<ThemeManager>();
}