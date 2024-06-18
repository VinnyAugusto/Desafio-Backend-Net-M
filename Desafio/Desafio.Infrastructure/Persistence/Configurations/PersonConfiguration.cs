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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> modelBuilder) 
        {
            modelBuilder
                .ToTable("TB_PERSON")
                .HasKey(p => p.Id);

            modelBuilder
                .HasIndex(p => p.Cnpj).IsUnique();
        }
    }
}
