using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Persistence.EntityConfigurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {

        public void Configure(EntityTypeBuilder<Room> entity)
        {
            entity.ToTable("room");

            entity.Property(e => e.RoomId).HasColumnName("roomId");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.RoomTypeId).HasColumnName("roomTypeId");
            entity.Property(e => e.PricePerNight).HasColumnName("pricePerNight");
        }
    }
}
