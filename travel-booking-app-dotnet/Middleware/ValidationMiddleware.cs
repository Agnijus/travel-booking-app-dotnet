using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using travel_booking_app_dotnet.Validation;

namespace travel_booking_app_dotnet.Middleware
{
    public static class ValidationMiddleware
    {
        public static IMvcBuilder AddTravelFluentValidation(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.Services.AddFluentValidationAutoValidation()
                               .AddFluentValidationClientsideAdapters();

            mvcBuilder.Services.AddValidatorsFromAssemblyContaining<PostHotelRequestValidator>();
            mvcBuilder.Services.AddValidatorsFromAssemblyContaining<PostBookingRequestValidator>();

            return mvcBuilder;
        }
    }
}
