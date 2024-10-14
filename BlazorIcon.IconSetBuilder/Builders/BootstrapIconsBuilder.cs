using System.Text;
using Rd.BlazorIcon.IconSetBuilder.Utilities;

namespace Rd.BlazorIcon.IconSetBuilder.Builders;

public class BootstrapIconsBuilder : IconSetBuilderBase
{
    protected override string InputDirectory => "../node_modules/bootstrap-icons/icons/";
    protected override string OutputDirectory => $"../BlazorIcon.BootstrapIcons/";
    protected override string OutputNamespace => "Rd.BlazorIcon.BootstrapIcons";
    protected override string OutputClassName => $"BootstrapIcons";
    protected override string VendorSource => "node_modules/bootstrap-icons/icons/(https://github.com/twbs/icons/)";
    protected override string VendorName => "Bootstrap Icons v1.11.3 (https://icons.getbootstrap.com/)";
    protected override string VendorCopyright => "Copyright 2019-2024 The Bootstrap Authors";
    protected override string VendorLicense => "Licensed under MIT (https://github.com/twbs/icons/blob/main/LICENSE)";
    
    public static void Build() => new BootstrapIconsBuilder().BuildIconSet();
}