using RentARabla.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Models
{
    public class Car
    {
        public int Id { get; set; }

        public Price PricePerDay { get; set; }
        public int ManufactureDate { get; set; }
        public FuelType FuelType { get; set; }
        public virtual CarType Type { get; set; }
        //public virtual CarBrand Brand { get; set; }

        public virtual CarModel Model { get; set; }

        public string ImageUrl { get; set; }
        public bool IsRented { get; set; }
    }
}