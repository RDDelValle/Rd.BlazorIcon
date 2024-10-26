using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Server.Client.Theme;

public partial class Theme : ComponentBase
{
    [Inject] private ThemeManager ThemeManager { get; set; } = default!;
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await ThemeManager.InitializeAsync();
        await base.OnAfterRenderAsync(firstRender);
    }
}