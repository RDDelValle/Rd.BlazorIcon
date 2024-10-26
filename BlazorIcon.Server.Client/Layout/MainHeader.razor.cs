using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Rd.BlazorIcon.Server.Client.Layout;

public partial class MainHeader : ComponentBase, IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    
    [Inject]
    private IJSRuntime JsRuntime { get; set; } = default!;

    public MainHeader()
    {
        _moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./Layout/MainHeader.razor.js").AsTask());
    }

    private async Task CloseOffcanvas(string selector)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("closeOffcanvas", selector);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}