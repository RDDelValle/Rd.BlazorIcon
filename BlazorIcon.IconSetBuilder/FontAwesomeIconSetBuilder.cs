namespace Rd.BlazorIcon.IconSetBuilder;

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

    public override void WriteToFile(bool printFileToConsole = false, bool writeToFile = true)
    {
        base.WriteToFile(printFileToConsole, writeToFile);
    }
}