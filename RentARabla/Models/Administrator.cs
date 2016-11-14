using RentARabla.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Models
{
    public class Administrator : Person
    {
        public Role Role { get; set; }
    }
}