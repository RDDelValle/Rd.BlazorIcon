using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Rd.BlazorIcon.Server.Client.Docs;

public partial class DocsSnippet : ComponentBase
{
    [Inject]
    private IJSRuntime JsRuntime { get; set; } = default!;
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private ElementReference _elementReference;
    
    [Parameter] public DocsSnippetLanguage Language { get; set; } = DocsSnippetLanguage.Xml;
    [Parameter] public RenderFragment? ChildContent { get; set; }

    public DocsSnippet()
    {
        _moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./Docs/DocsSnippet.razor.js").AsTask());
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("highlightSnippet", _elementReference, Language.ToString().ToLower());
        await base.OnAfterRenderAsync(firstRender);
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

public enum DocsSnippetLanguage
{
    Bash,
    CSharp,
    Css,
    Javascript,
    Xml
}