using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rd.BlazorIcon.Server.Client.Theme;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTheme();

await builder.Build().RunAsync();
