using travel_app;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

var env = app.Environment;
startup.Configure(app, env);

app.Run();