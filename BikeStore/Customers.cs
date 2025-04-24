using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Customers
    {
        //static variable to generate unique customer IDs
        private static int nextId = 1;

        public int CustomerId { get; set; }
        public int FullName { get; set; }
        public int Email { get; set; }
        public int Address { get; set; }
        public int PhoneNumber { get; set; }
        public int MissedViewing { get; set; }


        //Constructor to create Customer Objects
        public Customers(int fullName, int email, int address, int phoneNumber)
        {
            //increase customer ID by one each time a new customer is added
            CustomerId = nextId;
            nextId = nextId + 1; 

            FullName = fullName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;

            //new customer so no missed bookings
            MissedViewing = 0;
        }
    
        //method to return all customer details
        public string GetDetails()
        {
            return  $"ID: {CustomerId} Name: {FullName} Email: {Email} Missed Viewings: {MissedViewing}";
        }

        public bool CanBookViewing
        {
            //if booking is less than 3 return true
            get
            {
                return MissedViewing < 3;
            }
        }

    
    }
}
