
using Application.Models.Requests;
using Domain.Entities;
using IntegrationTests.Helpers;
using Newtonsoft.Json;
using System.Net;

namespace IntegrationTests.Tests
{
    public class HotelBookingControllerTest : IClassFixture<TestFixture>
    {
        private readonly HotelBookingHelper _hotelBookingHelper;
        private readonly HotelHelper _hotelHelper;

        public HotelBookingControllerTest(TestFixture fixture)
        {
            _hotelBookingHelper = new HotelBookingHelper(fixture);
            _hotelHelper = new HotelHelper(fixture);
        }

        //[Fact]
        //public async Task POST_CreatesBooking_Returns200()
        //{
        //    // Arrange
        //    var request = new PostBookingRequest
        //    {
        //        FirstName = "Agnijus",
        //        LastName = "Botyrius",
        //        Email = "agnijus@gmail.com",
        //        ContactNumber = "123456789",
        //        HotelId = 1,
        //        RoomTypeId = 1,
        //        CheckInDate = new DateTime(2024, 7, 7),
        //        CheckOutDate = new DateTime(2024, 7, 24),
        //        TotalPrice = 1250
        //    };

        //    // Act
        //    var apiResponse = await _hotelBookingHelper.CreateBooking(request);

        //    // Assert
        //    Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
        //    Assert.True(apiResponse.IsSuccess);
        //    Assert.NotNull(apiResponse.Data);
        //}

        [Fact]
        public async Task GET_GetsBookingById_Returns200()
        {
            var createHotelRequest = new PostHotelRequest
            {
                Title = "Hotel B",
                Address = "456 Another St",
                City = "London",
                Distance = 3.2d,
                StarRating = 5,
                GuestRating = 4.7d,
                ReviewCount = 200,
                HasFreeCancellation = false,
                HasPayOnArrival = true
            };

            var hotelResponse = await _hotelHelper.CreateHotel(createHotelRequest);
            Assert.True(hotelResponse.IsSuccess);
            Assert.NotNull(hotelResponse.Data);

            var hotel = JsonConvert.DeserializeObject<Hotel>(hotelResponse.Data.ToString());
            var hotelId = hotel.HotelId;

            var roomTypeId = 1;

            var request = new PostBookingRequest
            {
                FirstName = "Agnijus",
                LastName = "Botyrius",
                Email = "agnijus@gmail.com",
                ContactNumber = "123456789",
                HotelId = hotelId,
                RoomTypeId = roomTypeId,
                CheckInDate = new DateTime(2024, 7, 7),
                CheckOutDate = new DateTime(2024, 7, 24),
                TotalPrice = 1250
            };

            var createResponse = await _hotelBookingHelper.CreateBooking(request);
            Assert.True(createResponse.IsSuccess);
            Assert.NotNull(createResponse.Data);

            var createdBooking = JsonConvert.DeserializeObject<Booking>(createResponse.Data.ToString());

            // Act
            var apiResponse = await _hotelBookingHelper.GetBookingById(createdBooking.BookingId);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }


        //[Fact]
        //public async Task GET_GetsBookingById_Returns200()
        //{
        //    // Arrange
        //    var request = new PostBookingRequest
        //    {
        //        FirstName = "Agnijus",
        //        LastName = "Botyrius",
        //        Email = "agnijus@gmail.com",
        //        ContactNumber = "123456789",
        //        HotelId = 1,
        //        RoomTypeId = 1,
        //        CheckInDate = new DateTime(2024, 7, 7),
        //        CheckOutDate = new DateTime(2024, 7, 24),
        //        TotalPrice = 1250
        //    };

        //    var createResponse = await _hotelBookingHelper.CreateBooking(request);
        //    var createdBooking = JsonConvert.DeserializeObject<Booking>(createResponse.Data.ToString());

        //    // Act
        //    var apiResponse = await _hotelBookingHelper.GetBookingById(createdBooking.BookingId);

        //    // Assert
        //    Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
        //    Assert.True(apiResponse.IsSuccess);
        //    Assert.NotNull(apiResponse.Data);
        //}

        [Fact]
        public async Task POST_CreatesBooking_Returns200()
        {
            // Step 1: Create a hotel using the HotelHelper
            var request = new PostHotelRequest
            {
                Title = "Hotel B",
                Address = "456 Another St",
                City = "London",
                Distance = 3.2d,
                StarRating = 5,
                GuestRating = 4.7d,
                ReviewCount = 200,
                HasFreeCancellation = false,
                HasPayOnArrival = true
            };

            var hotelResponse = await _hotelHelper.CreateHotel(request);
            Assert.True(hotelResponse.IsSuccess);
            Assert.NotNull(hotelResponse.Data);

            var hotel = JsonConvert.DeserializeObject<Hotel>(hotelResponse.Data.ToString());
            var hotelId = hotel.HotelId;

            // Step 2: Assume RoomTypeId is 1 for simplicity, or create a room if necessary
            // If you have a RoomHelper or a way to create a RoomType, you should call that here
            var roomTypeId = 1; // Replace this with actual room type creation if needed

            // Step 3: Create a booking using the HotelId and RoomTypeId
            var bookingRequest = new PostBookingRequest
            {
                FirstName = "Agnijus",
                LastName = "Botyrius",
                Email = "agnijus@gmail.com",
                ContactNumber = "123456789",
                HotelId = hotelId,
                RoomTypeId = roomTypeId,
                CheckInDate = new DateTime(2024, 7, 7),
                CheckOutDate = new DateTime(2024, 7, 24),
                TotalPrice = 1250
            };

            var apiResponse = await _hotelBookingHelper.CreateBooking(bookingRequest);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            Assert.True(apiResponse.IsSuccess);
            Assert.NotNull(apiResponse.Data);
        }

        [Fact]
        public async Task GET_GetsBookingById_Returns404()
        {
            // Act
            var apiResponse = await _hotelBookingHelper.GetBookingById(1);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.NotFound, actual: (int)apiResponse.StatusCode);
            Assert.False(apiResponse.IsSuccess);
            Assert.Null(apiResponse.Data);
        }

        [Fact]
        public async Task DELETE_DeletesBookingById_Returns200()
        {
            // Arrange
            var request = new PostBookingRequest
            {
                FirstName = "Agnijus",
                LastName = "Botyrius",
                Email = "agnijus@gmail.com",
                ContactNumber = "123456789",
                HotelId = 1,
                RoomTypeId = 1,
                CheckInDate = new DateTime(2024, 7, 7),
                CheckOutDate = new DateTime(2024, 7, 24),
                TotalPrice = 1250
            };

            var createdResponse = await _hotelBookingHelper.CreateBooking(request);


            // Act
            //var apiResponse = await _hotelBookingHelper.DeleteBookingById(createResponse.Data.BookingId);

            //// Assert
            //Assert.Equal(expected: (int)HttpStatusCode.OK, actual: (int)apiResponse.StatusCode);
            //Assert.True(apiResponse.IsSuccess);
        }


        [Fact]
        public async Task DELETE_DeletesBookingById_Returns404()
        {
            // Act
            var apiResponse = await _hotelBookingHelper.DeleteBookingById(10);

            // Assert
            Assert.Equal(expected: (int)HttpStatusCode.NotFound, actual: (int)apiResponse.StatusCode);
            Assert.False(apiResponse.IsSuccess);
            Assert.Null(apiResponse.Data);
        }
    }
}
