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


            }
        }
    }
}
