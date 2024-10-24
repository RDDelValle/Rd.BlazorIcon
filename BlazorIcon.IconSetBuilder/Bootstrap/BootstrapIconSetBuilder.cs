using Rd.BlazorIcon.IconSetBuilder.Builders;

namespace Rd.BlazorIcon.IconSetBuilder.Bootstrap;

public class BootstrapIconSetBuilder : IconSetFileBuilder
{
    public string SvgIconsDirectory { get; set; } = "../node_modules/bootstrap-icons/icons";
    public override string OutputDirectory { get; init; } = "../BlazorIcon.Bootstrap";
    public override string OutputFilename { get; init; } = "BootstrapIcons";

    public override IconSetClassBuilder IconSetClassBuilder { get; init; } = new IconSetClassBuilder
    {
        ProjectRepo = "https://github.com/RDDelValle/Rd.BlazorIcon",
        Namespace = "Rd.BlazorIcon.Bootstrap",
        PrimaryClass = "BootstrapIcons",
        VendorName = "Bootstrap Icons v1.11.3 (https://icons.getbootstrap.com/)",
        VendorSource = "node_modules/bootstrap-icons/icons/(https://github.com/twbs/icons/)",
        VendorLicense = "Licensed under MIT (https://github.com/twbs/icons/blob/main/LICENSE)",
        VendorCopyright = "Copyright 2019-2024 The Bootstrap Authors",
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
            svg.Attribute("class")?.Remove();
            svg.Attribute("fill")?.Remove();
            svg.Attribute("width")?.Remove();
            svg.Attribute("height")?.Remove();
            var formattedSvg = svg.ToString().Replace("\r", "").Replace("\n", "").Replace("\"", "\"\"").Replace(">  <", "><");
            IconSetClassBuilder.AddIcon(svgName, formattedSvg);
        }
    }
}