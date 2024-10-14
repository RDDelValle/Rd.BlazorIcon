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
    string ColorString { get; set; }
    IReadOnlyList<FieldInfo> FilteredIcons { get; }
    void OnColorChange(ChangeEventArgs args);
    FieldInfo? SelectedIcon { get; }
    void SelectIcon(FieldInfo icon);
    void DeselectIcon();
}