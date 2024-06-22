using FluentValidation;
using FluentValidation.AspNetCore;
using travel_app.Validation;

namespace travel_app.Middleware
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
