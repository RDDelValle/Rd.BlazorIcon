using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Rd.BlazorIcon.Bootstrap;

namespace Rd.BlazorIcon.Demo;

public partial class App : ComponentBase, IApp
{
    [Inject] public IJSRuntime Js { get; set; } = default!;
    
    private List<FieldInfo> Icons => SelectedStyleType
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(fi => fi is { IsLiteral: true, IsInitOnly: false }).ToList();

    public double IconSize { get; set; } = 3;
    
    public async void OnIconSizeChange(ChangeEventArgs args)
    {
       IconSize = double.Parse((args.Value as string)!);
       Console.WriteLine($"Icon Size: {IconSize}");
       await InvokeAsync(StateHasChanged);
    }

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
        await Js.InvokeVoidAsync("localStorage.setItem", "Style", SelectedStyleString);
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

    protected override async Task OnInitializedAsync()
    {
        var selectedStyle = await Js.InvokeAsync<string?>("localStorage.getItem", "Style");
        if (selectedStyle != null)
        {
            SelectedStyleString = selectedStyle;
            await InvokeAsync(StateHasChanged);
        }
    }
}