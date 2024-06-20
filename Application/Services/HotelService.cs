using Application.Interfaces;
using Domain.Exceptions;
using Application.Models.Requests;
using travel_booking_app_dotnet.Core.Entities;
using travel_booking_app_dotnet.Core.Repository_Interfaces;


namespace Application.Services
{
    public class HotelService : IHotelService
    {

        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> GetAllAsync()
        {
            var hotels = _hotelRepository.GetAllAsync();

            return hotels;
        }

        public Hotel GetByIdAsync(int id)
        {
            var hotel = _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new HotelNotFoundException(id);
            }

            return hotel;
        }

        public List<Hotel> GetByDestinationAsync(string destination)
        {
            var hotels = _hotelRepository.GetAllAsync();

            var filteredHotels = hotels.Where(h => h.City == destination).ToList();

            return filteredHotels;

        }

        public Hotel CreateAsync(PostHotelRequest request)
        {
            var hotel = new Hotel
            {
                Name = request.Name,
                Images = request.Images,
                Address = request.Address,
                City = request.City,
                Distance = request.Distance,
                StarRating = request.StarRating,
                GuestRating = request.GuestRating,
                ReviewCount = request.ReviewCount,
                HasFreeCancellation = request.HasFreeCancellation,
                HasPayOnArrival = request.HasPayOnArrival,
                Rooms = request.Rooms
            };

            _hotelRepository.Add(hotel);

            return hotel;
        }

        public void DeleteByIdAsync(int id)
        {
            var hotel = _hotelRepository.GetByIdAsync(id);

            if (hotel is null)
            {
                throw new HotelNotFoundException(id);
            }

            _hotelRepository.Delete(hotel);
        }
    }
}
