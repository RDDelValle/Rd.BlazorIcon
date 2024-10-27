using Rd.BlazorIcon.Bootstrap;
using Rd.BlazorIcon.FontAwesome;
using Rd.BlazorIcon.Material;

namespace Rd.BlazorIcon.Server.Client.Demo;

public static class DemoServiceCollectionExtensions
{
    public static IServiceCollection AddDemo(this IServiceCollection services)
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
                },
                new DemoIconSet {
                    Name = "Material Baseline Icons",
                    Logo = FontAwesomeIcons.Brands.Google,
                    Type = typeof(MaterialIcons.Baseline)
                },
                new DemoIconSet {
                    Name = "Material Outline Icons",
                    Logo = FontAwesomeIcons.Brands.Google,
                    Type = typeof(MaterialIcons.Outline)
                },
                new DemoIconSet {
                    Name = "Material Round Icons",
                    Logo = FontAwesomeIcons.Brands.Google,
                    Type = typeof(MaterialIcons.Round)
                },
                new DemoIconSet {
                    Name = "Material Sharp Icons",
                    Logo = FontAwesomeIcons.Brands.Google,
                    Type = typeof(MaterialIcons.Sharp)
                },
                new DemoIconSet {
                    Name = "Material TwoTone Icons",
                    Logo = FontAwesomeIcons.Brands.Google,
                    Type = typeof(MaterialIcons.TwoTone)
                }
            ];
        });

        services.AddScoped<DemoIconManager>();
        return services;
    }
}