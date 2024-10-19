using Microsoft.Extensions.Options;
using Rd.BlazorIcon.Demo.Options;

namespace Rd.BlazorIcon.Demo.Managers;

public class DemoIconManager(IOptions<DemoOptions> options)
{
    public IEnumerable<DemoIconSet> IconSets => options.Value.DemoIconSets;

    public EventHandler? _onSelectedIconSetChange;
    public event EventHandler OnSelectedIconSetChange
    {
        add => _onSelectedIconSetChange += value;
        remove => _onSelectedIconSetChange -= value;
    }

    public DemoIconSet SelectedIconSet { get; private set; } = options.Value.DemoIconSets.First();

    public ValueTask SelectIconSetAsync(DemoIconSet iconSet)
    {   
        if(iconSet == SelectedIconSet)
            return ValueTask.CompletedTask;
        SelectedIconSet = iconSet;
        _onSelectedIconSetChange?.Invoke( this, EventArgs.Empty );
        return ValueTask.CompletedTask;
    }

}