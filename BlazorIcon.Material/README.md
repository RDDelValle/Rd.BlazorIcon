# Material Icons for BlazorIcon

Material Icons to be used with BlazorIcon component

Package Version: 1.0.1

NuGet Package: *[Rd.BlazorIcon.Material](https://www.nuget.org/packages/Rd.BlazorIcon.Material)*

Demo Application:  https://blazoricon.ramondev.com


### Installation
1) Install Packages
```
dotnet add package Rd.BlazorIcon
dotnet add package Rd.BlazorIcon.Material
```
    
2) Add using for package in _Imports.razor
```
@using Rd.BlazorIcon
@using Rd.BlazorIcon.Material
```

3) Add app stylesheet to index.html or app.razor
```
<link href="{Your.Project.Namespace}.styles.css" rel="stylesheet" />
```

### Usage

1) Add BlazorIcon component and define icon to use
```
<BlazorIcon Icon="@MaterialIcons.{Baseline|Outline|Round|Sharp|TwoTone}.{IconName}" />
```

### Parameters

1) BaseClass
2) Class
3) Icon
4) Title
5) IsFixedWidth
6) Size
7) AriaHidden
8) Focusable
9) AdditionalAttributes


##### Change Log
* 1.0.1
  * Refactor reserved keyword icon name Equals to _Equals