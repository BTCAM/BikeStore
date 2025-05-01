using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Staff
    {
        public string Name { get; set; }
        public List<DateTime> UnavaliableTimes { get; set; }

        public Staff(string name)
        {
            Name = name;
            //create a list for that staff member
            UnavaliableTimes = new List<DateTime>();

        }

        //Method to check if staff member is availble at a specific time
        public bool IsAvaible(DateTime time)
        {
            return !UnavaliableTimes.Contains(time);

        }
    }
}

