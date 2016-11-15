using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Models
{
    public class l_CarTypeBrand
    {
        public int Id { get; set; }
        public virtual CarType CarTypeId { get; set; }
        public virtual CarBrand CarBrandId { get; set; }
    }
}