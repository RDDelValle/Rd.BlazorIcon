using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon;

public abstract class BlazorIconBase : ComponentBase
{
    protected string? FormattedIcon
        => string.IsNullOrWhiteSpace(Icon)
            ? null
            : Icon.Replace(@"<svg\b[^>]*>", string.Empty)
                .Replace(@"<\/svg>", string.Empty);

    protected string? ViewBox
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Icon))
                return null;
            var pattern = "viewBox=\"([^\"]+)\"";
            var match = Regex.Match(Icon, pattern);
            return match.Success ? match.Groups[1].Value : null;
        }
    }

    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Icon { get; set; }
    [Parameter] public bool AriaHidden { get; set; } = true;
    [Parameter] public bool Focusable { get; set; }
}