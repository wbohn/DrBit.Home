using DrBit.Home.Components;
using DrBit.Home.Config;
using Microsoft.AspNetCore.DataProtection;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

var dataProtectionKeysPath =
    Environment.GetEnvironmentVariable("DATA_PROTECTION_KEYS_PATH")
    ?? Path.Combine(builder.Environment.ContentRootPath, ".keys");

builder.Services
    .AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(dataProtectionKeysPath))
    .SetApplicationName("DrBit.Home");

builder.Configuration.AddJsonFile(ServiceLinks.FileName);
builder.Services.Configure<ServiceLinks>(
    builder.Configuration.GetSection(ServiceLinks.OptionName));

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
