using Desafio.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Desafio.Infrastructure.Persistence
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }

        public DbSet<DeliveryPerson> DeliveryPerson { get; set; }

        public DbSet<Motorcycle> Motorcycle { get; set; }

        public DbSet<Rent> Rent { get; set; }

        public DbSet<Rent> RentPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
