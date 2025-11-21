using IrteyaTestTask.UI.Application.Services;
using IrteyaTestTask.UI.Domain.Models;
using IrteyaTestTask.UI.Infrastructure;
using IrteyaTestTask.UI.Infrastructure.WeatherRepositories;
using IrteyaTestTask.UI.Services;
using IrteyaTestTask.UI.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseSqlite("Data Source=weather.db"));

builder.Services.AddScoped<IWeatherRepository, EfWeatherRepository>();

builder.Services.AddScoped<IWeatherService, WeatherService>();
//builder.Services.AddScoped<IWeatherRepository, InMemoryWeatherRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
    //db.Database.Migrate();
}

app.Run();
