using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class HotelReservationConfiguration : IEntityTypeConfiguration<HotelReservation>
{
    public void Configure(EntityTypeBuilder<HotelReservation> entity)
    {
        entity.ToTable("hotelReservation");

        entity.Property(e => e.HotelReservationId).HasColumnName("hotelReservationId");
        entity.Property(e => e.HotelId).HasColumnName("hotelId");
        entity.Property(e => e.RoomTypeId).HasColumnName("roomTypeId");
        entity.Property(e => e.CheckInDate).HasColumnName("checkInDate");
        entity.Property(e => e.CheckOutDate).HasColumnName("checkOutDate");
        entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

        entity.HasOne(hr => hr.Hotel)
            .WithMany()  
            .HasForeignKey(hr => hr.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(hr => hr.RoomType)
            .WithMany()  
            .HasForeignKey(hr => hr.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
