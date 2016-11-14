using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentARabla.Contexts
{
    public class RentARablaDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().Map(m =>
            {
                m.ToTable("Administrator");
            });
            modelBuilder.Entity<Client>().Map(m =>
            {
                m.ToTable("Client");
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Administrator> Administrators { get; set; }

    }
}