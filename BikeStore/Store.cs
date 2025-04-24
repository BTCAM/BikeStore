using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Store
    {
        public List<Bikes> Bikes {  get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<Staff> StaffMembers { get; set; }
        public List<Viewings> Viewings { get; set; }

        public Store()
        {
            Bikes = new List<Bikes>();
            CustomersList = new List<Customers>();
            StaffMembers = new List<Staff>();
            Viewings = new List<Viewings>();
        }

        //Method to take in a Staff Object and store in the List StaffMembers
        public void AddStaff(Staff staff)
        {
            StaffMembers.Add(staff);
        }
        //Method to take in a Customer Object and store in the List Customers
        public void AddCustomer(Customers Customer)
        {
            CustomersList.Add(Customer);
        }

        //Method to take in a Bike Object and store in the List Bikes
        public void AddBikes(Bikes Bike)
        {
            Bikes.Add(Bike);
        }



    }
}
