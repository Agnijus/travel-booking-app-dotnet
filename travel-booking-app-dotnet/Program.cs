using Services.Abstractions;
using Services;
using travel_booking_app_dotnet.Controllers;
using travel_booking_app_dotnet.Core.Repository_Interfaces;
using Persistence.Repositories;
using Domain.Repository_Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddApplicationPart(typeof(HotelController).Assembly);

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddScoped<IHotelBookingService, HotelBookingService>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();

builder.Services.AddScoped<IGuestAccountRepository, GuestAccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();