using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence.Data
{
    public class DbContextMembers : DbContext
    {
        public DbContextMembers(DbContextOptions<DbContextMembers> options)
               : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<GuestAccount> GuestAccounts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<HotelReservation> HotelReservations { get; set; }
        public virtual DbSet<PopularDestination> PopularDestinations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BookingConfiguration().Configure(modelBuilder.Entity<Booking>());
            new GuestAccountConfiguration().Configure(modelBuilder.Entity<GuestAccount>());
            new HotelConfiguration().Configure(modelBuilder.Entity<Hotel>());
            new HotelImageConfiguration().Configure(modelBuilder.Entity<HotelImage>());
            new HotelReservationConfiguration().Configure(modelBuilder.Entity<HotelReservation>());
            new PopularDestinationConfiguration().Configure(modelBuilder.Entity<PopularDestination>());
            new RoomConfiguration().Configure(modelBuilder.Entity<Room>());
            new RoomTypeConfiguration().Configure(
                modelBuilder.Entity<RoomType>());
            new TransactionStatusConfiguration().Configure(modelBuilder.Entity<TransactionStatus>());
        }
    }
}
