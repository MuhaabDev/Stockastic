using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stockastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Stockastic.Data.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasOne(u => u.Portfolio)
            .WithOne(p => p.User)
            .HasForeignKey<Portfolio>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasKey(u => u.Id);
    }   
}