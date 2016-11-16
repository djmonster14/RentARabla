namespace RentARabla.Migrations
{
    using Enums;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RentARabla.Contexts.RentARablaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
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

            context.Administrators.Add(
                new Administrator
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Password = "admin",
                    Email = "admin@mail.com",
                    Phone = "0721341290",
                    Role = Role.Admin,
                });
        }

        private void SeedCars(Contexts.RentARablaDBContext context)
        {
            var car = context.Cars.FirstOrDefault();
            if (car != null)
                return;

            var vw = new CarBrand { Value = "Volkswagen" };
            var bmw = new CarBrand { Value = "BMW" };
            var tesla = new CarBrand { Value = "Tesla" };
            var dacia = new CarBrand { Value = "Dacia" };

            var jeep = new CarType { Value = "Jeep" };
            var luxury = new CarType { Value = "Luxury" };

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 35
                },
                ManufactureDate = 2016,
                FuelType = FuelType.Diesel,
                Type = jeep,
                Model = new CarModel
                {
                    Value = "Duster",
                    CarBrand = dacia
                },
            });
            context.l_CarTypesBrands.Add(new l_CarTypeBrand
            {
                CarBrandId = dacia,
                CarTypeId = jeep
            });

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 40
                },
                ManufactureDate = 2010,
                FuelType = FuelType.Electric,
                Type = luxury,
                Model = new CarModel
                {
                    Value = "S",
                    CarBrand = tesla
                }
            });
            context.l_CarTypesBrands.Add(new l_CarTypeBrand
            {
                CarBrandId = tesla,
                CarTypeId = luxury
            });

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 120
                },
                ManufactureDate = 2014,
                FuelType = FuelType.Petrol,
                Type = luxury,
                Model = new CarModel
                {
                    Value = "2 Series",
                    CarBrand = bmw
                }
            });
            context.l_CarTypesBrands.Add(new l_CarTypeBrand
            {
                CarBrandId = bmw,
                CarTypeId = luxury
            });

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 45
                },
                ManufactureDate = 2012,
                FuelType = FuelType.Petrol,
                Type = jeep,
                Model = new CarModel
                {
                    Value = "Tuareg",
                    CarBrand = vw
                }
            });
            context.l_CarTypesBrands.Add(new l_CarTypeBrand
            {
                CarBrandId = vw,
                CarTypeId = jeep
            });

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 55
                },
                ManufactureDate = 2004,
                FuelType = FuelType.Diesel,
                Type = jeep,
                Model = new CarModel
                {
                    Value = "X6",
                    CarBrand = bmw
                }
            });
            context.l_CarTypesBrands.Add(new l_CarTypeBrand
            {
                CarBrandId = bmw,
                CarTypeId = jeep
            });

            context.Cars.Add(new Car
            {
                PricePerDay = new Price
                {
                    Currency = Currency.EUR,
                    PriceValue = 43
                },
                ManufactureDate = 2006,
                FuelType = FuelType.Diesel,
                Type = jeep,
                Model = new CarModel
                {
                    Value = "Tiguan",
                    CarBrand = vw
                }
            });
        }

        private void SeedClients(Contexts.RentARablaDBContext context)
        {
            var clients = context.Clients.FirstOrDefault();
            if (clients != null)
                return;

            context.Clients.Add(
                new Client
                {
                    FirstName = "Matei",
                    LastName = "Serafim",
                    UserName = "client",
                    Password = "client",
                    Email = "mserafim@yahoo.com",
                    Phone = "0744012012",
                    Age = 24,
                    NationalId = "321132142132",
                    Address = new Address
                    {
                        Street = "Mihai Viteazul",
                        StreetNumber = 4,
                        City = "Cluj-Napoca",
                        Country = "Romania"
                    }
                });
        }

    }
}
