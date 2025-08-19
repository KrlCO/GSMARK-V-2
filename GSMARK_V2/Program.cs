using GSMARK_V2.Components;
using GSMARK_V2.Helpers;
using GSMARK_V2.Interfaces;
using GSMARK_V2.Repository;
using GSMARK_V2.Services;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


// Configuración de la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar IDbConnection como scoped
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));


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
builder.Services.AddScoped<ITMITEMRepository, TMITEMRepository>();
builder.Services.AddScoped<ITMITEMService, TMITEMService>();


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
