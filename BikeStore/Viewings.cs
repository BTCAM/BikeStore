using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Viewings
    {
        public Customers Customer { get; set; }
        public Bikes Bikes { get; set; }

        public Staff Staff { get; set; }

        public DateTime ViewingTime { get; set; }
        public string Status { get; set; }

        public Viewings(Customers customer, Bikes bikes, Staff staff, DateTime viewingTime)
        {
            Customer = customer;
            Bikes = bikes;
            Staff = staff;
            ViewingTime = viewingTime;
            Status = "Bookings";
        }
    }
}
