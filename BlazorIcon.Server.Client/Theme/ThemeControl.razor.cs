using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Server.Client.Theme;

public partial class ThemeControl : ComponentBase, IAsyncDisposable
{
    [Inject] private ThemeManager ThemeManager { get; set; } = default!;

    protected override Task OnInitializedAsync()
    {
        ThemeManager.OnSelectedThemeChanged += OnSelectedThemeChanged;
        return base.OnInitializedAsync();
    }

    private async void OnSelectedThemeChanged(object? sender, EventArgs e)
    {
        await InvokeAsync(StateHasChanged);
    }

    public ValueTask DisposeAsync()
    {
        ThemeManager.OnSelectedThemeChanged -= OnSelectedThemeChanged;
        return ValueTask.CompletedTask;
    }
}