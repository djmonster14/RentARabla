using RentARabla.Enums;
using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Helpers
{
    public class RentalsSearch
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Price PricePerDay { get; set; }
        public DateTime ManufactureDate { get; set; }
        public FuelType FuelType { get; set; }
        public CarType Type { get; set; }
        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }
    }
}