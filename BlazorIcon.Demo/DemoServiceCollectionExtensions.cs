using Microsoft.Extensions.DependencyInjection;
using Rd.BlazorIcon.Bootstrap;
using Rd.BlazorIcon.FontAwesome;

namespace Rd.BlazorIcon.Demo;

public static class DemoServiceCollectionExtensions
{
    public static IServiceCollection AddBlazorIconDemo(this IServiceCollection services)
    {
        services.Configure<DemoOptions>(options =>
        {
            options.DemoIconSets = [
                new DemoIconSet {
                    Name = "Bootstrap Icons",
                    Logo = BootstrapIcons.Bootstrap,
                    Type = typeof(BootstrapIcons)
                },
                new DemoIconSet {
                    Name = "Font Awesome Regular Icons",
                    Logo = FontAwesomeIcons.Regular.FontAwesome,
                    Type = typeof(FontAwesomeIcons.Regular)
                },
                new DemoIconSet {
                    Name = "Font Awesome Solid Icons",
                    Logo = FontAwesomeIcons.Solid.FontAwesome,
                    Type = typeof(FontAwesomeIcons.Solid)
                },
                new DemoIconSet {
                    Name = "Font Awesome Brand Icons",
                    Logo = FontAwesomeIcons.Brands.FontAwesome,
                    Type = typeof(FontAwesomeIcons.Brands)
                }
            ];
        });
        return services;
    }
}