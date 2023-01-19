using BeagleStreetApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IWeatherService>(x =>
    new WeatherService(
        builder.Configuration.GetSection("WeatherApi").GetValue<string>("BaseUrl"),
        builder.Configuration.GetSection("WeatherApi").GetValue<string>("Token")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();
