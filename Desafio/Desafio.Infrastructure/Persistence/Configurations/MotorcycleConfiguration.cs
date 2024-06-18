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
    public class MotorcycleConfiguration : IEntityTypeConfiguration<Motorcycle>
    {
        public void Configure(EntityTypeBuilder<Motorcycle> modelBuilder) 
        {
            modelBuilder
                .ToTable("TB_MOTORCYCLE")
                .HasKey(p => p.Id);

            modelBuilder
                .HasMany(p => p.RelatedRentals)
                .WithOne(f => f.Motorcycle)
                .HasForeignKey(i => i.IdMotorcycle);

            modelBuilder
                .HasIndex(p => p.Plate).IsUnique();
        }
    }
}
