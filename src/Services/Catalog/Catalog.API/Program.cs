var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(config =>
{
    config.Connection(builder.Configuration.GetConnectionString("Database")!);
    config.DisableNpgsqlLogging = true;
}).UseLightweightSessions();


var app = builder.Build();

// Configure the HTTP request pipline.
app.MapCarter();


app.Run();
