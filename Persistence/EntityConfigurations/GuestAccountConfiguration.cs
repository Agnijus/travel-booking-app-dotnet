using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class GuestAccountConfiguration : IEntityTypeConfiguration<GuestAccount>
{
    public void Configure(EntityTypeBuilder<GuestAccount> entity)
    {
        entity.ToTable("guestAccount");

        entity.Property(e => e.GuestAccountId).HasColumnName("guestAccountId");
        entity.Property(e => e.FirstName).HasColumnName("firstName");
        entity.Property(e => e.LastName).HasColumnName("lastName");
        entity.Property(e => e.Email).HasColumnName("email");
        entity.Property(e => e.ContactNumber).HasColumnName("contactNumber");
    }
}