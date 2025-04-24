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
                Console.WriteLine("Customer Opitions: ");
                Console.WriteLine(" 1. Add Customer");
                Console.WriteLine(" 2. View All Customers");

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



            

            }
        }
    }
}
