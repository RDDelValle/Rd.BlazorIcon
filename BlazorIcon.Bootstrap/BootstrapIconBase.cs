using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Bootstrap;

public class BootstrapIconBase : ComponentBase
{
    protected string? CssClass => string.IsNullOrWhiteSpace(BaseClass) 
        ? string.IsNullOrWhiteSpace(Class)
            ? null
            : Class
        : $"{BaseClass} {Class}";
    protected virtual string? BaseClass { get; } = "bi";
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Fill { get; set; } = "currentColor";
    [Parameter] public string? ViewBox { get; set; } = "0 0 16 16";
    [Parameter] public int? Width { get; set; } = 16;
    [Parameter] public int? Height { get; set; } = 16;
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Icon { get; set; } = BootstrapIcons.QuestionCircleFill;
    [Parameter] public bool AriaHidden { get; set; } = true;
    [Parameter] public bool Focusable { get; set; }
}