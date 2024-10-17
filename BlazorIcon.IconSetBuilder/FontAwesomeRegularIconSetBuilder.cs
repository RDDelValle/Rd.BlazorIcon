using System.Text.RegularExpressions;

namespace Rd.BlazorIcon.IconSetBuilder;

public class FontAwesomeRegularIconSetBuilder : IconSetFileBuilder
{
    public string SvgIconsDirectory { get; set; } = "../node_modules/@fortawesome/fontawesome-free/svgs/regular";
    public override string OutputDirectory { get; init; } = "../BlazorIcon.FontAwesome";
    public override string OutputFilename { get; init; } = "Regular";

    public override IconSetClassBuilder IconSetClassBuilder { get; init; } = new IconSetClassBuilder
    {
        ProjectRepo = "https://github.com/RDDelValle/Rd.BlazorIcon",
        Namespace = "Rd.BlazorIcon.FontAwesome",
        PrimaryClass = "FontAwesomeIcons",
        SecondaryClass = "Regular",
        VendorName = "Font Awesome Free 6.6.0 by @fontawesome - https://fontawesome.com",
        VendorSource = "node_modules/@fortawesome/fontawesome-free/svgs/regular(https://github.com/FortAwesome/Font-Awesome)",
        VendorLicense = "https://fontawesome.com/license/free (Icons: CC BY 4.0, Fonts: SIL OFL 1.1, Code: MIT License)",
        VendorCopyright = "Copyright 2024 Fonticons, Inc.",
    };
    
    public override string[]? WhiteListIcons { get; init; }
    protected override void BuildIconSet()
    {
        foreach (var file in GetSvgFilesFromDirectory(SvgIconsDirectory))
        {
            if(WhiteListIcons != null && !WhiteListIcons.Contains(file.Split("/").Last().Split(".").First()))
                continue;
            var svgName = file.ToCSharpPropertyName();
            var svg = ReadSvgFile(file);
            var formattedSvg = svg.ToString().Replace("\r", "").Replace("\n", "").Replace("\"", "\"\"").Replace(">  <", "><");
            formattedSvg = Regex.Replace(formattedSvg, "<!--.*?-->", "");
            IconSetClassBuilder.AddIcon(svgName, formattedSvg);
        }
    }
}