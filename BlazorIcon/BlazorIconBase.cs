using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon;

public abstract class BlazorIconBase : ComponentBase
{
    protected string? CssClass => string.IsNullOrWhiteSpace(BaseClass) ? Class : $"{BaseClass} {Class}";
    protected virtual string? BaseClass { get; }
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? ViewBox { get; set; } = "0 0 16 16";
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Icon { get; set; }
    [Parameter] public bool AriaHidden { get; set; } = true;
    [Parameter] public bool Focusable { get; set; }
}