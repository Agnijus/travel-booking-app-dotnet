using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class TransactionStatusConfiguration : IEntityTypeConfiguration<TransactionStatus>
{
    public void Configure(EntityTypeBuilder<TransactionStatus> entity)
    {
        entity.ToTable("transactionStatus");

        entity.Property(e => e.TransactionStatusId).HasColumnName("transactionStatusId");
        entity.Property(e => e.Description).HasColumnName("description");
    }
}