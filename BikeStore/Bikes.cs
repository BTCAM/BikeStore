using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Bikes
    {
        public string BikeID {  get; set; }
        public string BikeType { get; set; }

        public string Address { get; set; }

        //Constructor to create any Bike Objects
        public Bikes(string bikeID, string bikeType, string address)
        {
            BikeID = bikeID;
            BikeType = bikeType;
            Address = address;
        }

        //Method to get details of Bike
        public string GetDetails()
        {
            return BikeType  + " - " + Address + " ID: " + BikeID;
        }

    }
}
