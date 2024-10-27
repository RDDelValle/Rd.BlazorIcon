using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Server.Client.Shared;

public class ButtonBase : ComponentBase
{
    protected virtual string BaseClass => "btn";

    protected string CssClass
    {
        get
        {
            var value = BaseClass;
            if(IsLarge)
                value += $" btn-lg";
            if(!string.IsNullOrEmpty(Class))
                value += $" {Class}";
            return value;
        }
    }

    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Href { get; set; }
    [Parameter] public string Type { get; set; } = "button";
    
    [Parameter] public bool IsLarge { get; set; }
    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}