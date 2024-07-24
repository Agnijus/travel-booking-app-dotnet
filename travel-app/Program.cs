using Serilog;
using travel_app;
using travel_app.Configurations;

var builder = WebApplication.CreateBuilder(args);

LoggerConfig.ConfigureLogger();
builder.Host.UseSerilog();

builder.Services.AddControllers();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

var env = app.Environment;
startup.Configure(app, env);

app.Run();