# Blazor Icon

A simple to use blazor icon component that allows you to use any svg as an icon.

Package Version: 1.1.0

NuGet Package: *[Rd.BlazorIcon](https://www.nuget.org/packages/Rd.BlazorIcon)*

Demo Application:  https://blazoricon.ramondev.com

### Installation
1) Install Package
```
dotnet add package Rd.BlazorIcon
```

2) Add using for package in _Imports.razor
```
@using Rd.BlazorIcon
```

3) Add app stylesheet to index.html or app.razor
```
<link href="{Your.Project.Namespace}.styles.css" rel="stylesheet" />
```

### Usage

1) Create a blazor icon
```
<BlazorIcon Icon="{AddSvgHere}" />
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
* 1.0.1:
  * Fix README install docs
* 1.0.2:
  * Add demo link to README
* 1.1.0:
  * Add BlazorIconSize enum and styling
  * Add IsFixedWidth parameter and styling
