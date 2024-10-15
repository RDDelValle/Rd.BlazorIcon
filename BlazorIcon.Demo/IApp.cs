using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Demo;

public interface IApp
{
    string? SearchString { get; set; }
    void OnSearchStringChange(ChangeEventArgs args);
    void ClearSearchString();
    IReadOnlyList<string> Styles { get; }
    string SelectedStyleString { get; set; }
    Type SelectedStyleType { get; }
    void OnSelectedStyleChange(ChangeEventArgs args);
    double IconSize { get; set; }
    void OnIconSizeChange(ChangeEventArgs args);
    IReadOnlyList<FieldInfo> FilteredIcons { get; }
    FieldInfo? SelectedIcon { get; }
    void SelectIcon(FieldInfo icon);
    void DeselectIcon();
}