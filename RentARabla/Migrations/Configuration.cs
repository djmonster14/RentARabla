namespace RentARabla.Migrations
{
    using Enums;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentARabla.Contexts.RentARablaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexts.RentARablaDBContext context)
        {
            SeedAdmin(context);
            SeedCars(context);
            SeedClients(context);
        }

        private void SeedAdmin(Contexts.RentARablaDBContext context)
        {
            var admin = context.Administrators.FirstOrDefault();
            if (admin != null)
                return;

            var person = new Person
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin",
                Password = "admin",
                Email = "admin@mail.com",
                Phone = "0721341290"
            };

            context.Administrators.Add(
                new Administrator
                {
                    Role = Role.Admin,
                    Person = person
                });
        }
        private void SeedCars(Contexts.RentARablaDBContext context) {
            var car = context.Cars.FirstOrDefault();
            if (car != null)
                return;
            var price1 = new Price
            {
                Currency = Currency.EUR,
                PriceValue = 35
            };
            var car1 = new Car
            {

                PricePerDay = price1,
                ManufactureDate = Convert.ToDateTime("01/08/2016"),
                FuelType = FuelType.Diesel,
                Type = CarType.Jeep,
                Brand = CarBrand.Dacia,
                Model = CarModel.Duster
            };

            var price2 = new Price
            {
                Currency = Currency.EUR,
                PriceValue = 40
            };
            var car2 = new Car
            {

                PricePerDay = price2,
                ManufactureDate = Convert.ToDateTime("01/08/2010"),
                FuelType = FuelType.Electric,
                Type = CarType.Luxury,
                Brand = CarBrand.Tesla,
                Model = CarModel.Roadster
            };

            var price3 = new Price
            {
                Currency = Currency.EUR,
                PriceValue = 45
            };
            var car3 = new Car
            {

                PricePerDay = price3,
                ManufactureDate = Convert.ToDateTime("05/08/2012"),
                FuelType = FuelType.Petrol,
                Type = CarType.Jeep,
                Brand = CarBrand.Volkswagen,
                Model = CarModel.Tuareg
            };

            context.Cars.Add(car1);
            context.Cars.Add(car2);
            context.Cars.Add(car3);
            //context.SaveChanges();
        }

        private void SeedClients(Contexts.RentARablaDBContext context)
        {
            var client = context.Administrators.FirstOrDefault();
            if (client != null)
                return;

            var address1 = new Address
            {
                Street = "Mihai Viteazul",
                StreetNumber = 4,
                City = "Cluj-Napoca",
                Country = "Romania"
            };

            var person1 = new Person
            {
                FirstName = "Matei",
                LastName = "Serafim",
                UserName = "mserafim",
                Password = "1234",
                Email = "mserafim@yahoo.com",
                Phone = "0744012012"
            };

            context.Clients.Add(
                new Client
                {
                    Age = 43,
                    NationalId = "1881101234432",
                    Person = person1,
                    Address = address1
                });

            var person2 = new Person
            {
                FirstName = "Sorin",
                LastName = "Decebal",
                UserName = "sdecebal",
                Password = "1234",
                Email = "sdecebal@yahoo.com",
                Phone = "0743123123"
            };

            context.Clients.Add(
                new Client
                {
                    Age = 47,
                    NationalId = "2841101342433",
                    Person = person2,
                    Address = address1
                });

            //context.SaveChanges();
        }

    }
}
