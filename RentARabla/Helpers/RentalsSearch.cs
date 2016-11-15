using RentARabla.Enums;
using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentARabla.Helpers
{
    public class RentalsSearch
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime RentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public Price PricePerDay { get; set; }
        public DateTime ManufactureDate { get; set; }
        public FuelType FuelType { get; set; }
        public string CarType { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
    }
}