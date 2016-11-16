using RentARabla.Enums;
using RentARabla.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public int ManufactureDate { get; set; }
        public FuelType FuelType { get; set; }

        public IEnumerable<SelectListItem> CarTypeList { get; set; }
        public CarType CarType { get; set; }

        public IEnumerable<SelectListItem> CarModelList { get; set; }
        public CarModel CarModel { get; set; }

        public List<Car> Cars { get; set; }

        public RentalsSearch()
        {
            RentDate = DateTime.Now;
            ReturnDate = DateTime.Now.AddDays(1);
            PricePerDay = new Price
            {
                Currency = Currency.LEI,
                PriceValue = 0
            };
            ManufactureDate = DateTime.Now.Year;
            FuelType = FuelType.Any;
        }
    }
}