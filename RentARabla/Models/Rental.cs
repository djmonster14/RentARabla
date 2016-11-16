using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentARabla.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Expired { get; set; }
        public virtual Client Client { get; set; }
        public virtual Car Car { get; set; }
    }
}