var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


app.MapGet("/time1", () => DateTime.UtcNow.ToString("o"));

app.Run();
