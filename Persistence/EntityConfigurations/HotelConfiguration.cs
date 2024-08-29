
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Persistence.EntityConfigurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> entity)
        {
            entity.ToTable("hotel");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.StarRating).HasColumnName("starRating");
            entity.Property(e => e.GuestRating).HasColumnName("guestRating");
            entity.Property(e => e.ReviewCount).HasColumnName("reviewCount");
            entity.Property(e => e.HasFreeCancellation).HasColumnName("hasFreeCancellation");
            entity.Property(e => e.HasPayOnArrival).HasColumnName("hasPayOnArrival");
        }
    }
}
