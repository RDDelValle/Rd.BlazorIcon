using Microsoft.AspNetCore.Components;

namespace BlazorIcon;

public abstract class BlazorIconBase : ComponentBase
{
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Fill { get; set; }
    [Parameter] public string? ViewBox { get; set; }
    [Parameter] public int? Width { get; set; }
    [Parameter] public int? Height { get; set; }
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Icon { get; set; }
    [Parameter] public bool AriaHidden { get; set; } = true;
    [Parameter] public bool Focusable { get; set; }
}