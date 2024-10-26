using Rd.BlazorIcon.Server.Client.Theme;
using Rd.BlazorIcon.Server.Client.ThemeColor;

namespace Rd.BlazorIcon.Server.Client;
public static class ClientServiceCollectionExtensions
{
    public static IServiceCollection AddServerClient(this IServiceCollection services)
        => services.AddTheme()
            .AddThemeColor();
}