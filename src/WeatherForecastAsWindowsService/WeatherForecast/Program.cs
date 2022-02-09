global using WeatherForecast.Data;
global using WeatherForecast.Services;
global using WeatherForecast.Workers;
using WeatherForecast.Brokers;

var builder = WebApplication.CreateBuilder(args);

// Add BackgroundService to the host.
builder.Host.UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
    })
    ;

builder.WebHost.UseUrls("http://localhost:5555", "http://0.0.0.0:5555");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//
builder.Services.AddDbContextFactory<WeatherForecastDbContext>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
