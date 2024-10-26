using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rd.BlazorIcon.Server.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddServerClient();

await builder.Build().RunAsync();
