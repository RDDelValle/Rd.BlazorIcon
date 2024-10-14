using System.Reflection;
using Microsoft.AspNetCore.Components;
using Rd.BlazorIcon.Bootstrap;

namespace Rd.BlazorIcon.Demo;

public partial class App : ComponentBase, IApp
{
    private List<FieldInfo> Icons => SelectedStyleType
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(fi => fi is { IsLiteral: true, IsInitOnly: false }).ToList();
    
    public IReadOnlyList<FieldInfo> FilteredIcons =>
        string.IsNullOrWhiteSpace(SearchString)
            ? Icons
            : Icons.Where(e =>
                    e.Name.Contains(SearchString, StringComparison.CurrentCultureIgnoreCase))
                .ToList();
    
    public string? SearchString { get; set; }
    public async void OnSearchStringChange(ChangeEventArgs args)
    {
        SearchString = args.Value?.ToString();
        await InvokeAsync(StateHasChanged);
    }

    public async void ClearSearchString()
    {
        SearchString = null;
        await InvokeAsync(StateHasChanged);
    }

    public const string BootstrapIcons = "Bootstrap Icons";
    public IReadOnlyList<string> Styles => [
        BootstrapIcons
    ];
    public string SelectedStyleString { get; set; } = BootstrapIcons;
    public Type SelectedStyleType => SelectedStyleString switch
    {
        BootstrapIcons => typeof(BootstrapIcons),
        _ => throw new ArgumentOutOfRangeException(nameof(SelectedStyleString))
    };
    public async void OnSelectedStyleChange(ChangeEventArgs args)
    {
        SelectedStyleString = args.Value?.ToString() ?? BootstrapIcons;
        await InvokeAsync(StateHasChanged);
    }

    public string ColorString { get; set; } = "#3880d7";
    
    public async void OnColorChange(ChangeEventArgs args)
    {
        ColorString = args.Value?.ToString() ?? "#3880d7";
        await InvokeAsync(StateHasChanged);
    }
    
    public FieldInfo? SelectedIcon { get; set; }

    public async void DeselectIcon()
    {
        SelectedIcon = null;
        await InvokeAsync(StateHasChanged);
    }

    public async void SelectIcon(FieldInfo icon)
    {
       SelectedIcon = icon;
       await InvokeAsync(StateHasChanged);
    }
}