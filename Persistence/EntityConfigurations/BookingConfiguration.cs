﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> entity)
    {
        entity.ToTable("booking");

        entity.Property(e => e.BookingId).HasColumnName("bookingId");
        entity.Property(e => e.GuestAccountId).HasColumnName("guestAccountId");
        entity.Property(e => e.HotelReservationId).HasColumnName("hotelReservationId");
        entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
        entity.Property(e => e.TransactionStatusId).HasColumnName("transactionStatusId");
    }
}