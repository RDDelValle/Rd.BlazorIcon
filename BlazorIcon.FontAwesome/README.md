# Bootstrap Icons for BlazorIcon

Bootstrap Icons to be used with BlazorIcon component

Package Version: 1.0.0

NuGet Package: *[Rd.BlazorIcon.Bootstrap](https://www.nuget.org/packages/Rd.BlazorIcon.FontAwesome)*

Demo Application:  https://blazoricon.ramondev.com


### Installation
1) Install Packages
```
dotnet add package Rd.BlazorIcon
dotnet add package Rd.BlazorIcon.FontAwesome
```
    
2) Add using for package in _Imports.razor
```
@using Rd.BlazorIcon
@using Rd.BlazorIcon.FontAwesome
```

3) Add app stylesheet to index.html or app.razor
```
<link href="{Your.Project.Namespace}.styles.css" rel="stylesheet" />
```

### Usage

1) Add using for package in _Imports.razor
```
<BlazorIcon Icon="@BootstrapIcons.FontAwesomeIcons.{Solid|Regular|Brands}.{IoonName}" />
```

### Parameters

1) Icon
2) Title
3) AriaHidden
4) Focusable


##### Change Log