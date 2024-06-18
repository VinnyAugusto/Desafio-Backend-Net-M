using Desafio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.Persistence.Configurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> modelBuilder) 
        {
            modelBuilder
                .ToTable("TB_RENT")
                .HasKey(p => p.Id);

            modelBuilder
                .HasOne(p => p.Motorcycle)
                .WithMany(f => f.RelatedRentals)
                .HasForeignKey(i => i.IdMotorcycle)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(p => p.DeliveryPerson)
                .WithMany(f => f.RelatedRentals)
                .HasForeignKey(i => i.IdMotorcycle)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
