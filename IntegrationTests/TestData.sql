
BEGIN TRANSACTION;

INSERT INTO TransactionStatus (Description)
VALUES ('Pending'), ('Confirmed'), ('Cancelled'), ('Failed');

INSERT INTO Hotel (Title, Address, City, Distance, StarRating, GuestRating, ReviewCount, HasFreeCancellation, HasPayOnArrival)
VALUES 
('Hotel A', '123 London St.', 'London', 10.0, 5, 8.5, 300, 1, 0),
('Hotel B', '456 Another St', 'London', 5.0, 4, 7.0, 150, 0, 1);

INSERT INTO RoomType (Description)
VALUES ('Single'), ('Double'), ('Suite');

INSERT INTO Room (HotelId, RoomTypeId, PricePerNight)
VALUES (1, 1, 100), (1, 2, 150), (2, 3, 200);

INSERT INTO HotelImage (HotelId, ImagePath)
VALUES (1, 'path/to/image1.jpg'), (2, 'path/to/image2.jpg');

INSERT INTO GuestAccount (FirstName, LastName, Email, ContactNumber)
VALUES 
('Agnijus', 'Botyrius', 'agnijus.botyrius@gmail.com', '1234567890');

INSERT INTO PopularDestination (City, Location)
VALUES 
('London', 'Covent Garden'), 
('Las Vegas', 'Paradise');

INSERT INTO HotelReservation (HotelId, RoomTypeId, CheckInDate, CheckOutDate, TotalPrice)
VALUES 
(1, 1, '2024-01-01', '2024-01-10', 900), 
(2, 3, '2024-01-15', '2024-01-25', 2500);

INSERT INTO Booking (GuestAccountId, HotelReservationId, TotalPrice, TransactionStatusId)
VALUES 
(1, 1, 900, 1), 
(1, 2, 2500, 2);

COMMIT TRANSACTION;
