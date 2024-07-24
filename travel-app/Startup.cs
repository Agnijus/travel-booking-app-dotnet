using Application.Interfaces;
using Application.Services;
using Domain.Repository_Interfaces;
using Persistence.Data;
using Persistence.Repositories;
using travel_app.Controllers;
using travel_app.Core.Repository_Interfaces;
using travel_app.Middleware;

namespace travel_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDapperContext, DapperContext>();

            services.AddControllers()
                .AddApplicationPart(typeof(HotelController).Assembly)
                .AddApplicationPart(typeof(HotelBookingController).Assembly)
                .AddTravelFluentValidation();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRepository, HotelRepository>();

            services.AddScoped<IHotelBookingService, HotelBookingService>();
            services.AddScoped<IHotelReservationDetailsRepository, HotelReservationDetailsRepository>();

            services.AddScoped<IGuestAccountRepository, GuestAccountRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IPopularDestinationRepository, PopularDestinationRepository>();
            services.AddScoped<IPopularDestinationService, PopularDestinationService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseCors("AllowLocalhost");

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
