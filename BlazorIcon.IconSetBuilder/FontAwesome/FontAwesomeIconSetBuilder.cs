using Rd.BlazorIcon.IconSetBuilder.Builders;

namespace Rd.BlazorIcon.IconSetBuilder.FontAwesome;

public class FontAwesomeIconSetBuilder : IconSetPartialFileBuilder
{
    public override string OutputDirectory { get; init; } = "../BlazorIcon.FontAwesome";
    public override string OutputFilename { get; init; } = "FontAwesomeIcons";

    public override IconSetPartialClassBuilder IconSetPartialClassBuilder { get; init; } =
        new IconSetPartialClassBuilder
        {
            Namespace = "Rd.BlazorIcon.FontAwesome",
            PrimaryClass = "FontAwesomeIcons",
            SecondaryClasses = ["Regular", "Solid", "Brands"],
        };
}