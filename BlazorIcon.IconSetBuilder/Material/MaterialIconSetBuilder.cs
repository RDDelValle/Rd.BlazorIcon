using Rd.BlazorIcon.IconSetBuilder.Builders;

namespace Rd.BlazorIcon.IconSetBuilder.Material;

public class MaterialIconSetBuilder : IconSetPartialFileBuilder
{
    public override string OutputDirectory { get; init; } = "../BlazorIcon.Material";
    public override string OutputFilename { get; init; } = "MaterialIcons";

    public override IconSetPartialClassBuilder IconSetPartialClassBuilder { get; init; } =
        new IconSetPartialClassBuilder
        {
            Namespace = "Rd.BlazorIcon.Material",
            PrimaryClass = "MaterialIcons",
            SecondaryClasses = ["Baseline", "Outline", "Round", "Sharp", "TwoTone"],
        };
}