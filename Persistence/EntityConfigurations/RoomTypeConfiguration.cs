using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations
{
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> entity)
        {
            entity.ToTable("roomType");

            entity.Property(e => e.RoomTypeId).HasColumnName("roomtypeId");
            entity.Property(e => e.Description).HasColumnName("description");

        }
    }
}
