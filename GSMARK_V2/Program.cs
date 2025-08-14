using GSMARK_V2.Components;
using GSMARK_V2.Helpers;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Repository;
using GSMARK_V2.Services;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Servicios de Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Servicios de MudBlazor
builder.Services.AddMudServices();

builder.Services.AddScoped<ITCVENTRepository, TCVENTRepository>();
builder.Services.AddScoped<ITCVENTService, TCVENTService>();
builder.Services.AddScoped<ITMPRODRepository, TMPRODRepository>();
builder.Services.AddScoped<ITMPRODService, TMPRODService>();

//MudBlazor
builder.Services.AddMudServices();

// Localizador dummy para que MudTablePager no falle
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(DummyStringLocalizer<>));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
