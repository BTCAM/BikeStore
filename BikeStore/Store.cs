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


        public Viewings BookViewing(string customername, string BikeId, string staffName, DateTime viewingTime)
        {

            //try to find the customer inb the list of customer in store object

            //blank customer object
            Customers customer = null;
            //loop through customer list
            foreach (Customers c in CustomersList)
            {
                //if the email used when calling the method (BookViewing)
                if (c.FullName == customername)
                {
                    //copy all details of that customer to the blank customer object
                    customer = c;
                        break;
                }
            }

            Bikes Bike = null;
            foreach (Bikes b in Bikes)
            {
      
                if (b.BikeID == BikeId)
                {
                  
                    Bike = b;
                    break;
                }
            }

            Staff staff = null;
            foreach (Staff s in StaffMembers)
            {
                if (s.Name == staffName)
                {
                    staff = s;
                    break;
                }
            }

            //we have now checked that staff, bike and customer are all real

            if (customer == null || Bike == null || staff == null)
            {
                Console.WriteLine("Error, Customer, Bike or Staff Member not found in store system");
                return null;
            }

            //check wheather the customer has missed too many prevoius viewing (3 Max)
            if (!customer.CanBookViewing)
            {
                Console.WriteLine("Customer has missed too many viewing. Cannot Book");
                return null;
            }

            //Check Staff to see if staff are free
            foreach (Viewings viewing in Viewings)
            {
                if (viewing.Staff.Name == staff.Name && viewing.ViewingTime == viewingTime)
                {
                    Console.WriteLine("Staff member is already booked for this time");
                    return null;
                }
            }

            //if all passes are check, add new viewing
            Viewings newViewing = new Viewings(customer, Bike, staff, viewingTime); //creates new viewing object
            Viewings.Add(newViewing); // add to viewing list in store object

            return newViewing; // return the successful booking

        }



    }
}
