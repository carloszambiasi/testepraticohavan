using System.Text.Json.Serialization;
using Havan.Tasks.Repositories;
using Havan.Tasks.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<
    ITaskRepository,
    InMemoryTaskRepository
>();

builder.Services.AddScoped<
    ITaskService,
    TaskService
>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Havan Tasks API v1"
        );
    });
}

app.MapControllers();

app.Run();