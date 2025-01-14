var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/time1", () => Results.Json(new
{
    Time = DateTime.UtcNow.ToString("o")
}));

app.MapControllers();

app.Run();
