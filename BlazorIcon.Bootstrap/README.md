# Bootstrap Icons for BlazorIcon

Bootstrap Icons to be used with BlazorIcon component

Package Version: 1.0.1

NuGet Package: *[Rd.BlazorIcon.Bootstrap](https://www.nuget.org/packages/Rd.BlazorIcon.Bootstrap)*

Demo Application:  https://blazoricon.ramondev.com


### Installation
1) Install Packages
```
dotnet add package Rd.BlazorIcon
dotnet add package Rd.BlazorIcon.Bootstrap
```
    
2) Add using for package in _Imports.razor
```
@using Rd.BlazorIcon
@using Rd.BlazorIcon.Bootstrap
```

3) Add app stylesheet to index.html or app.razor
```
<link href="{Your.Project.Namespace}.styles.css" rel="stylesheet" />
```

### Usage

1) Add using for package in _Imports.razor
```
<BlazorIcon Icon="@BootstrapIcons.{AnyBootstrapIcon}" />
```

### Parameters

1) Icon
2) Title
3) AriaHidden
4) Focusable


##### Change Log
* 1.0.1:
    * Add deno link to README 