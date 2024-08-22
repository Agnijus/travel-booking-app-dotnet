using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
{
    public void Configure(EntityTypeBuilder<HotelImage> entity)
    {
        entity.ToTable("hotelImage");

        entity.Property(e => e.HotelImageId).HasColumnName("hotelImageId");
        entity.Property(e => e.HotelId).HasColumnName("hotelId");
        entity.Property(e => e.ImagePath).HasColumnName("imagePath");

        entity.HasOne(hi => hi.Hotel)
            .WithMany(h => h.HotelImages)
            .HasForeignKey(hi => hi.HotelId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}