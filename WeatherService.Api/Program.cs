using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using WeatherService.Api.Middlewares;
using WeatherService.Business.Services.Interfaces;
using WeatherService.Business.Utils;
using WeatherService.Business.Utils.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IHttpUtil, HttpUtil>();
builder.Services.AddScoped<IWeatherService, WeatherService.Business.Services.WeatherService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" });
});

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API V1");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
