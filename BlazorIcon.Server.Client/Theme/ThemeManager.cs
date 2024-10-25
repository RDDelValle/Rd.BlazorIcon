using Microsoft.JSInterop;
using Rd.BlazorIcon.Bootstrap;

namespace Rd.BlazorIcon.Server.Client.Theme;

public class ThemeManager(IJSRuntime jsRuntime) : IAsyncDisposable
{
    private bool _isInitialized;
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        "import", "./Theme/Theme.razor.js").AsTask());

    private const string Auto = nameof(Auto);
    private const string Light = nameof(Light);
    private const string Dark = nameof(Dark);
    
    public readonly IReadOnlyDictionary<string, string> Themes
        = new Dictionary<string, string>
        {
            { Auto, BootstrapIcons.CircleHalf },
            { Light, BootstrapIcons.SunFill },
            { Dark, BootstrapIcons.MoonStarsFill }
        };
    
    public string SelectedTheme { get; private set; } = Auto;
    private EventHandler? _onSelectedThemeChanged;

    public event EventHandler? OnSelectedThemeChanged
    {
        add => _onSelectedThemeChanged += value;
        remove => _onSelectedThemeChanged -= value;
    }
    
    public async ValueTask InitializeAsync()
    {
        if (_isInitialized)
            throw new InvalidOperationException("Theme is already initialized");
        _isInitialized = true;
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("initialize");
        SelectedTheme = await module.InvokeAsync<string>("getUserPreferredTheme");
        _onSelectedThemeChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public async ValueTask SelectThemeAsync(string theme)
    {
        if (theme.Equals(SelectedTheme))
            return;
        SelectedTheme = theme;
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setUserPreferredTheme", SelectedTheme);
        _onSelectedThemeChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public bool IsSelectedTheme(string theme)
        => SelectedTheme.Equals(theme);
    
    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}