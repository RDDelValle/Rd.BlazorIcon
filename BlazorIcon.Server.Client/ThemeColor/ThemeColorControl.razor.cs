using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Server.Client.ThemeColor;

public partial class ThemeColorControl : ComponentBase, IAsyncDisposable
{
    [Inject] private ThemeColorManager ThemeColorManager { get; set; } = default!;
    
    protected override Task OnInitializedAsync()
    {
        ThemeColorManager.OnSelectedThemeColorChanged += OnSelectedThemeColorChanged;
        return base.OnInitializedAsync();
    }
    
    private async void OnSelectedThemeColorChanged(object? sender, EventArgs e)
    {
        await InvokeAsync(StateHasChanged);
    }

    public ValueTask DisposeAsync()
    {
        ThemeColorManager.OnSelectedThemeColorChanged -= OnSelectedThemeColorChanged;
        return ValueTask.CompletedTask;
    }
}