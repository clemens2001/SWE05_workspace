using System.Text.Json;
using OrderManagement.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    })
    .AddXmlDataContractSerializerFormatters();

//builder.Services.AddSingleton<IOrderManagementLogic, OrderManagementLogic>(); // für die gesamte Anwendung/Laufzeit wird nur eine Instanz erstellt
//builder.Services.AddTransient<IOrderManagementLogic, OrderManagementLogic>(); // bei jedem Aufruf wird eine neue Instanz erstellt

// bei jedem Request wird eine neue Instanz erstellt
// es wird ein scope erstellt, der für die gesamte Requestdauer gültig ist
builder.Services.AddScoped<IOrderManagementLogic, OrderManagementLogic>();   


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
