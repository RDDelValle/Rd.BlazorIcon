using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon;

public abstract class BlazorIconBase : ComponentBase
{
    protected string? FormattedIcon
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Icon))
                return null;

            string openingTagPattern = @"<svg\b[^>]*>";
            string closingTagPattern = @"<\/svg>";

            var svgString = Icon;
            // Remove the opening svg tag
            svgString = Regex.Replace(svgString, openingTagPattern, "", RegexOptions.IgnoreCase);
            // Remove the closing svg tag
            svgString = Regex.Replace(svgString, closingTagPattern, "", RegexOptions.IgnoreCase);
            return svgString;
        }
    }

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


    protected string? CssClass
        => BuildCssClass();

    [Parameter] public string BaseClass { get; set; } = "blazor-icon";
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Icon { get; set; }
    [Parameter] public BlazorIconSize Size { get; set; }
    [Parameter] public bool IsFixedWidth { get; set; }
    [Parameter] public bool AriaHidden { get; set; } = true;
    [Parameter] public bool Focusable { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected virtual string BuildCssClass()
    {
        var sb = new StringBuilder();
        sb.Append($"{BaseClass} ");
        if (IsFixedWidth)
            sb.Append("is-fw ");
        if (Size != BlazorIconSize.Default)
            sb.Append($"is-{Size.ToString()!.Replace("_", string.Empty).ToLower()} ");
        if (!string.IsNullOrWhiteSpace(Class))
            sb.Append($"{Class} ");
        return sb.ToString().TrimEnd(' ');
    }
}