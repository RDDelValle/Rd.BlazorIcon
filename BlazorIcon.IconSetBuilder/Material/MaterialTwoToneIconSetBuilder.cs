using Rd.BlazorIcon.IconSetBuilder.Builders;

namespace Rd.BlazorIcon.IconSetBuilder.Material;

public class MaterialTwoToneIconSetBuilder : IconSetFileBuilder
{
    public string SvgIconsDirectory { get; set; } = "../node_modules/@material-icons/svg/svg";
    public override string OutputDirectory { get; init; } = "../BlazorIcon.Material";
    public override string OutputFilename { get; init; } = "TwoTone";
    private string InputFileName { get; init; } = "twotone";

    public override IconSetClassBuilder IconSetClassBuilder { get; init; } = new IconSetClassBuilder
    {
        ProjectRepo = "https://github.com/RDDelValle/Rd.BlazorIcon",
        Namespace = "Rd.BlazorIcon.Material",
        PrimaryClass = "MaterialIcons",
        SecondaryClass = "TwoTone",
        VendorName = "MaterialIcons by Google",
        VendorSource = "node_modules/@material-icons/svg/svg(https://github.com/material-icons/material-icons)",
        VendorLicense = "https://github.com/material-icons/material-icons/blob/master/LICENSE (Apache License 2.0)",
        VendorCopyright = "?",
    };
    
    public override string[]? WhiteListIcons { get; init; }
    protected override void BuildIconSet()
    {
        foreach (var directory in GetDirectoriesFromDirectory(SvgIconsDirectory))
        {
            var svgName = directory.ToCSharpPropertyName();
            var svgFileName = GetSvgFileFromDirectory(directory, InputFileName);
            if(WhiteListIcons != null && !WhiteListIcons.Contains(svgName))
                continue;
            if(svgName.Equals("Equals"))
                svgName = "_Equals";
            var svg = ReadSvgFile(svgFileName);
            svg.Attribute("width")?.Remove();
            svg.Attribute("height")?.Remove();
            var formattedSvg = svg.ToString().Replace("\r", "").Replace("\n", "").Replace("\"", "\"\"").Replace(">  <", "><");
            IconSetClassBuilder.AddIcon(svgName, formattedSvg);
        }
    }
}