namespace Application.Models
{
    public class Constant
    {
        public const string HotelNotFoundError = "Hotel with an id of {0} not found";
        public const string HotelDestinationNotFoundError = "Hotel with a destination of {0} not found";
        public const string HotelsNotFoundError = "No hotels found";
        public const string HotelBookingNotFoundError = "Hotel booking with an id of {0} not found";
        public const string PopularDestinationsNotFoundError = "Popular destinations not found";
        public const string DatabaseConnectionError = "Failed to create a database connection";

        public const string GetHotelBookingByIdSuccess = "GET booking by id successful";
        public const string PostHotelBookingSuccess = "POST booking request successful";
        public const string DeleteHotelBookingSuccess = "DELETE booking by id successful";

        public const string GetAllHotelsSuccess = "GET all hotels successful";
        public const string GetHotelByIdSuccess = "GET hotel by id successful";
        public const string GetHotelByDestinationSuccess = "GET hotels by destination successful";
        public const string PostHotelSuccess = "POST Hotel request successful";

        public const string GetAllPopularDestinationSuccess = "GET all popular destinations successful";
    }
}
