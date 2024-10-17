# Blazor Icon

A simple to use blazor icon component that allows you to use any svg as an icon.

Package Version: 1.0.0

NuGet Package: *[Rd.BlazorIcon.Bootstrap](https://www.nuget.org/packages/Rd.BlazorIcon.Bootstrap)*


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

