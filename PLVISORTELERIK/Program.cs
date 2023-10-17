using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using PLVISORTELERIK.Auth;
using PLVISORTELERIK.Configuration;
using PLVISORTELERIK.Data;
using PLVISORTELERIK.Helpers;
using PLVISORTELERIK.Shared;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;
using Telerik.WebReportDesigner.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

string Dominio = (builder.Configuration.GetSection("Dominio")).Value;
string path = (builder.Configuration.GetSection(@$"ReportSettings:{Dominio}")).Value;
//var pathofexile = (builder.Configuration.GetSection("ReportSettings:ReportPath")); 
var reportsPath = Path.Combine(builder.Environment.ContentRootPath, path);

builder.Services.TryAddSingleton<IReportServiceConfiguration>(sp => new ReportServiceConfiguration
{
    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
    HostAppId = "Net7BlazorNativeDemo",
    Storage = new FileStorage(),
    ReportSourceResolver = new UriReportSourceResolver(System.IO.Path.Combine(reportsPath))
});




// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddRazorPages().AddNewtonsoftJson();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddRazorPages()
                .AddNewtonsoftJson();
builder.Services.AddCors(opts => opts.AddDefaultPolicy(p => {
    p.AllowAnyOrigin();
    p.AllowAnyMethod();
    p.AllowAnyHeader();
}));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddScoped<HttpClient>();

builder.Services.AddScoped<IMostrarMensajes, MostrarMensajes>();
builder.Services.AddScoped<IMensajeToastr, MensajeToastr>();
builder.Services.AddScoped<IDataTable, DataTable>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<MainLayout>();

builder.Services.AddScoped<ProveedorAutenticacionJWT>();
builder.Services.AddScoped<AuthenticationStateProvider, ProveedorAutenticacionJWT>(
    provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<ILoginService, ProveedorAutenticacionJWT>(
   provider => provider.GetRequiredService<ProveedorAutenticacionJWT>());
builder.Services.AddScoped<RenovadorToken>();
builder.Services.AddScoped<UserJWT>();

builder.Services.AddConfReposirioHTTP(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


