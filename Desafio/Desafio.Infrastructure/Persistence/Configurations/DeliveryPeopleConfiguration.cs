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
    public class DeliveryPersonConfiguration : IEntityTypeConfiguration<DeliveryPerson>
    {
        public void Configure(EntityTypeBuilder<DeliveryPerson> modelBuilder)
        {
            modelBuilder
                .ToTable("TB_DELIVERY_PERSON")
                .HasKey(p => p.Id);

            modelBuilder
                .HasOne(p => p.Person)
                .WithOne(f => f.DeliveryPerson)
                .HasForeignKey<DeliveryPerson>(i => i.IdPerson)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasIndex(p => p.CnhNumber).IsUnique();

        }
    }
}
