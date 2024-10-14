using Microsoft.AspNetCore.Components;

namespace Rd.BlazorIcon.Demo;

public abstract class AppComponentBase : ComponentBase
{
    [CascadingParameter] public IApp App { get; set; } = default!;
}