using System.Reflection;
using Microsoft.Extensions.Options;

namespace Rd.BlazorIcon.Server.Client.Demo;

public class DemoIconManager(IOptions<DemoOptions> options)
{
    public FieldInfo? SelectedIcon { get; private set; }
    private EventHandler? _onSelectedIconChange;
    public event EventHandler OnSelectedIconChange
    {
        add => _onSelectedIconChange += value;
        remove => _onSelectedIconChange -= value;
    }

    private EventHandler? _onIconSetChange;
    public event EventHandler OnIconSetChange
    {
        add => _onIconSetChange += value;
        remove => _onIconSetChange -= value;
    }

    public string? FilterString { get; internal set; }
    public int IconSize { get; internal set; } = 3;
    public IEnumerable<DemoIconSet> IconSets => options.Value.DemoIconSets;

    public DemoIconSet SelectedIconSet { get; private set; } = options.Value.DemoIconSets.First();


    public IReadOnlyList<FieldInfo> FilteredIcons =>
        string.IsNullOrWhiteSpace(FilterString)
            ? Icons
            : Icons.Where(e =>
                    e.Name.Contains(FilterString, StringComparison.CurrentCultureIgnoreCase))
                .ToList();

    public List<FieldInfo> Icons
        => SelectedIconSet
            .Type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi is { IsLiteral: true, IsInitOnly: false }).ToList();
    
    public void SelectIcon(FieldInfo icon)
    {
        if (icon == SelectedIcon)
            return;
        SelectedIcon = icon;
        _onSelectedIconChange?.Invoke(this, EventArgs.Empty);
    }

    public void DeselectIcon()
    {
        if (SelectedIcon is null)
            return;
        SelectedIcon = null;
        _onSelectedIconChange?.Invoke(this, EventArgs.Empty);
    }


    public void SelectIconSet(DemoIconSet iconSet)
    {
        if (iconSet == SelectedIconSet)
            return;
        SelectedIconSet = iconSet;
        _onIconSetChange?.Invoke(this, EventArgs.Empty);
    }

    public void FilterIconSet(string filterString)
    {
        if (filterString.Equals(FilterString, StringComparison.CurrentCultureIgnoreCase))
            return;
        FilterString = filterString;
        _onIconSetChange?.Invoke(this, EventArgs.Empty);
    }

    public void SizeIconSet(int size)
    {
        if (size == IconSize)
            return;
        IconSize = size;
        _onIconSetChange?.Invoke(this, EventArgs.Empty);
    }

}