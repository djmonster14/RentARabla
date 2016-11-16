using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Models
{
    public class CarType
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual IList<Car> Cars { get; set; }
    }
}