using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Starter_CleanArch_UAA2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starter_CleanArch_UAA2.Infrastructure.Database.Configs
{
    internal class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("Subscribers"); 

            builder.HasKey(s => s.Id)
                .HasName("PK_Subscribers")
                .IsClustered();

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(s => s.Email)
                .IsUnique();

            builder.Property(s => s.Nouveautes)
                .HasDefaultValue(false);

            builder.Property(s => s.RecapitulatifMois)
                .HasDefaultValue(false);

            builder.Property(s => s.FaitDuJour)
                .HasDefaultValue(false);
        }
    }
}
