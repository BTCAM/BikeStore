using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Customers
    {
        //static variable to generate unique customer IDs
        private static int nextId = 1;

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int MissedViewing { get; set; }


        //Constructor to create Customer Objects with their details
        public Customers(string fullName, string email, string address, string phoneNumber)
        {
            //increase customer ID by one each time a new customer is added
            CustomerId = nextId;
            nextId = nextId + 1;

            //Set the customer's personal details
            FullName = fullName;
            Email = email;
            Address = address;
            PhoneNumber = phoneNumber;

            //new customer so no missed bookings
            MissedViewing = 0;
        }

        //Method to return a string with customer details
        public string GetDetails()
        {
            return  $"ID: {CustomerId} Name: {FullName} Email: {Email} Missed Viewings: {MissedViewing}";
        }

        //check if the customer can book a viewing
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
