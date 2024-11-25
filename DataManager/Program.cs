using DataManager;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var configuration = builder.Configuration;

// 从 appsettings.json 读取并绑定到 EnvSettings 类
builder.Services.Configure<List<EnvSettings>>(builder.Configuration.GetSection("EnvSettings"));
// 注册 EmailService
builder.Services.AddTransient<IEnvService, EnvService>();

var app = builder.Build();

// 使用依赖注入获取配置
// app.MapGet("/", (IOptions<EnvSettings> mySettings) =>
// {
//     var settings = mySettings.Value;
//     return $"App Name: {settings.ApplicationName}, Version: {settings.Version}, APIKey: {settings.APIKey}";
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseRouting();

app.UseAuthorization();

// 映射控制器的路由
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
