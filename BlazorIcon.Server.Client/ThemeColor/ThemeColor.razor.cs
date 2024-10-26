using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Server.Client.ThemeColor;

public partial class ThemeColor : ComponentBase, IAsyncDisposable
{
    [Inject] private ThemeColorManager ThemeColorManager { get; set; } = default!;

    protected override Task OnInitializedAsync()
    {
        ThemeColorManager.OnSelectedThemeColorChanged += OnSelectedThemeColorChanged;
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if(firstRender)
            await ThemeColorManager.InitializeAsync();
        
        await base.OnAfterRenderAsync(firstRender);
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