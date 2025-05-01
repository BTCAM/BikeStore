namespace BikeStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a store
            Store store1 = new Store();

            //add staff members to store using AddStaff method and the Constructor from the Staff Class
            store1.AddStaff(new Staff("Alice"));
            store1.AddStaff(new Staff("Bart"));

            Console.WriteLine("Welcome to the Bike Store");

            //Menu System
            //flag used to exit the program
            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine("\n --------------------- Main Menu --------------");
                Console.WriteLine("---Customer Opitions: ");
                Console.WriteLine(" 1. Add Customer");
                Console.WriteLine(" 2. View All Customers");
                Console.WriteLine(" 3. Filter Customer By Name");

                Console.WriteLine("---Bikes Opitions: ");
                Console.WriteLine("4. Add Bike ");
                Console.WriteLine("5. View All Bikes ");
                Console.WriteLine("6. Filter Bike By Address ");


                Console.WriteLine("---Viewing Opitions: ");
                Console.WriteLine("7. Add New Booking ");
                Console.WriteLine("8. View all Bookings ");
                Console.WriteLine("9. Adjust Bookings ");
                Console.WriteLine("10. Find Booking ");


                Console.WriteLine("11. Quit ");

                string opition = Console.ReadLine();

                //Allows user to add new customer
                if (opition == "1")
                {
                    Console.WriteLine("Enter Full Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Email:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Enter Address:");
                    string address = Console.ReadLine();

                    Console.WriteLine("Enter Phone Number:");
                    string phoneNumber = Console.ReadLine();

                    Customers newCustomer = new Customers(name, email, address, phoneNumber);
                    store1.AddCustomer(newCustomer);
                    Console.WriteLine("Customer has been added");
                }
                else if (opition == "2")
                {
                    Console.WriteLine("All Customers");
                    foreach (Customers customer in store1.CustomersList)
                    {
                        Console.WriteLine(customer.GetDetails());

                        if (customer.CanBookViewing)
                        {
                            Console.WriteLine("Status: Can make Booking");
                        }
                        else
                        {
                            Console.WriteLine("Status: Blocked from Bookings");
                        }



                    }
                }
                else if (opition == "3")
                {
                    Console.WriteLine("Enter Customer Name");
                    string name = Console.ReadLine();

                    foreach (Customers customer in store1.CustomersList)
                    {
                        if (customer.FullName == name)
                        {
                            Console.WriteLine(customer.GetDetails());
                        }
                    }
                }
                else if (opition == "4")
                {
                    Console.WriteLine("Bike ID: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Bike Type");
                    string type = Console.ReadLine();

                    Console.WriteLine("Address");
                    string address = Console.ReadLine();

                    store1.AddBikes(new Bikes(id, type, address));
                }

                else if (opition == "5")
                {
                    foreach (Bikes bike in store1.Bikes)
                    {
                        Console.WriteLine(bike.GetDetails());
                    }
                }
                else if (opition == "6")
                {
                    Console.WriteLine("Enter Bike Address");
                    string address = Console.ReadLine();

                    foreach (Bikes bike in store1.Bikes)
                    {
                        if (bike.Address == address)
                        {
                            Console.WriteLine(bike.GetDetails());
                        }
                    }
                }
                else if (opition == "7")
                {
                    Console.WriteLine("Customer Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Bike Id");
                    string bikeId = Console.ReadLine();
                    Console.WriteLine("Staff name: ");
                    string staffname = Console.ReadLine();

                    Console.WriteLine("Viewing Time (yyyy-MM-dd HH:mm):");
                    string timeInput = Console.ReadLine();
                    DateTime viewingTime = DateTime.Parse(timeInput);

                    //Method to create booking
                    store1.BookViewing(name, bikeId, staffname, viewingTime);

                }
                else if (opition == "8")
                {
                    foreach (Viewings viewing in store1.Viewings)
                    {
                        Console.WriteLine($"{viewing.Customer.FullName} - {viewing.Bikes.Address} - {viewing.Staff.Name} - {viewing.ViewingTime} | {viewing.Status}");
                    }
                }
                else if (opition == "9")
                {
                    Console.WriteLine("Enter Customer ID of the Viewing to Adjust: ");
                    int customerId;
                    bool parsed = Int32.TryParse(Console.ReadLine(), out customerId);
                    if (!parsed)
                    {
                        Console.WriteLine("Invalid ID");
                        continue;
                    }

                    //Find viewing 
                    Viewings viewing = null;
                    foreach (var v in store1.Viewings)
                    {
                        if (v.Customer.CustomerId == customerId)
                        {
                            viewing = v;
                            break;
                        }
                    }

                    //used to modify viewing
                    if (viewing != null)
                    {
                        Console.WriteLine("Current Status: " + viewing.Status);
                        Console.WriteLine("Enter new status (Booked, Viewing Attended, Viewing Missed, Cancelled: ");
                        string newStatus = Console.ReadLine();

                        store1.AdjustViewingStatus(viewing.Customer.CustomerId, newStatus);
                    }
                    else
                    {
                        Console.WriteLine("Viewing not found");
                    }
                }
                else if (opition == "10")
                {
                    Console.WriteLine("Enter Customer ID");
                    int customerID;
                    bool validID = Int32.TryParse(Console.ReadLine(), out customerID);

                    if (!validID)
                    {
                        Console.WriteLine("Invalid ID");
                        continue;
                    }

                    Viewings foundviewing = null;
                    foreach (var v in store1.Viewings)
                    {
                        if (v.Customer.CustomerId == customerID)
                        {
                            foundviewing = v;
                            break;
                        }
                    }
                    if (foundviewing != null)
                    {
                        Console.WriteLine($"Viewing for Customer: {foundviewing.Customer.FullName}");
                        Console.WriteLine($"Property: {foundviewing.Bikes.GetDetails()}");
                        Console.WriteLine($"Staff: {foundviewing.Staff.Name}");
                        Console.WriteLine($"Time: {foundviewing.ViewingTime}");
                        Console.WriteLine($"Status: {foundviewing.Status}");
                    }
                    else
                    {
                        Console.WriteLine("No viewings found for that customer ID");
                    }

                }
                else if (opition == "11")
                {
                    exitMenu = true;
                    Console.WriteLine("Exiting system");
                }
            }
        }
    }
}
