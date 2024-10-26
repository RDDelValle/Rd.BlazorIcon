using Microsoft.JSInterop;

namespace Rd.BlazorIcon.Server.Client.ThemeColor;

public class ThemeColorManager(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private bool _isInitialized;
    
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./ThemeColor/ThemeColor.razor.js").AsTask());
    
    public string SelectedThemeColor { get; internal set; } = "#000000";
    private EventHandler? _onSelectedThemeColorChanged;

    public event EventHandler? OnSelectedThemeColorChanged
    {
        add => _onSelectedThemeColorChanged += value;
        remove => _onSelectedThemeColorChanged -= value;
    }
    
    public async ValueTask InitializeAsync()
    {
        if (_isInitialized)
            throw new InvalidOperationException("ThemeColor is already initialized");
        _isInitialized = true;
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("initialize");
        SelectedThemeColor = await module.InvokeAsync<string>("getThemeColor");
        _onSelectedThemeColorChanged?.Invoke(this, EventArgs.Empty);
    }

    public async ValueTask SelectThemeColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        SelectedThemeColor = color;
        await module.InvokeVoidAsync("setThemeColor", SelectedThemeColor);
        _onSelectedThemeColorChanged?.Invoke(this, EventArgs.Empty);
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