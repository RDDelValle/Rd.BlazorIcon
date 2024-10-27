using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Rd.BlazorIcon.Server.Client.ScrollToTop;

public partial class ScrollToTop : ComponentBase
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    [Inject] private IJSRuntime JsRuntime { get; set; } = default!;
    private bool IsVisible { get; set; }

    public ScrollToTop()
    {
        _moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./ScrollToTop/ScrollToTop.razor.js").AsTask());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Subscribe to window scroll event
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("initialize", DotNetObjectReference.Create(this));
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    [JSInvokable]
    public async ValueTask OnScroll()
    {
        // Show button if scrolled more than 50% of the viewport height
        // var scrollY = (double)JS.InvokeAsync<double>("window.pageYOffset").Result;
        // var viewportHeight = (double)JS.InvokeAsync<double>("window.innerHeight").Result;
        var module = await _moduleTask.Value;
        var visible = await module.InvokeAsync<bool>("isScrolledPastHalfOfViewport");
        
        if(IsVisible == visible)
            return;
        
        IsVisible = visible;
        StateHasChanged();
    }

    private async Task ScrollTop()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollToTop");
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