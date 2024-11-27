using System.Text.Json;
using OrderManagement.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(builder =>
    builder.AddDefaultPolicy(policy => 
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

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

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddOpenApiDocument(settings => settings.Title = "Order Management API");

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.UseOpenApi();
app.UseSwaggerUi(settings => settings.Path = "/swagger");
app.UseReDoc(app => app.Path = "/redoc");

app.Run();
