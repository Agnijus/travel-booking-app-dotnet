using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class PopularDestinationConfiguration : IEntityTypeConfiguration<PopularDestination>
{
    public void Configure(EntityTypeBuilder<PopularDestination> entity)
    {
        entity.ToTable("popularDestination");

        entity.HasKey(e => e.Id).HasName("PK_PopularDestination");
        entity.Property(e => e.Id).HasColumnName("PopularDestinationId");

        entity.Property(e => e.City).HasColumnName("city");
        entity.Property(e => e.Location).HasColumnName("location");
    }
}