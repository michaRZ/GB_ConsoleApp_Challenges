using KomodoGreetings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoGreetings_Console
{
    public class ProgramUI
    {
        private readonly CustomerRepository _repo = new CustomerRepository();

        public void Run()
        {
            SeedCustomers();
            Menu();
        }

        public void SeedCustomers()
        {
            Customer c1 = new Customer("Pheobe", "Buffay", Type.past);
            Customer c2 = new Customer("Chandler", "Bing", Type.current);
            Customer c3 = new Customer("Rachel", "Green", Type.potential);
            Customer c4 = new Customer("Joey", "Tribbiani", Type.current);

            _repo.AddCustomerToDirectory(c1);
            _repo.AddCustomerToDirectory(c2);
            _repo.AddCustomerToDirectory(c3);
            _repo.AddCustomerToDirectory(c4);
        }
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                string title = @"

            ______ __                      _________      
            ___  //_/____________ _______________  /_____ 
            __  ,<  _  __ \_  __ `__ \  __ \  __  /_  __ \
            _  /| | / /_/ /  / / / / / /_/ / /_/ / / /_/ /
            /_/ |_| \____//_/ /_/ /_/\____/\__,_/  \____/ 
     _                               _                             
    /       _ _|_  _  ._ _   _  ._  | \  _. _|_  _. |_   _.  _  _  
    \_ |_| _>  |_ (_) | | | (/_ |   |_/ (_|  |_ (_| |_) (_| _> (/_ 
                                                                
";


                Console.WriteLine(title);

                Console.WriteLine("Menu:\n" +
                    "1. View all customers\n" +     // currently default list; will update to alphabetically if I can get that working
                    "2. View customers by type\n" +
                    "3. Add new customer\n" +
                    "4. Update existing customer\n" +
                    "5. Delete customer\n" +
                    "6. Exit\n");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    case "all":
                        // show all customers
                        DisplayAllCustomers();
                        break;
                    case "2":
                    case "type":
                        // show customers of type
                        DisplayCustomersOfType();
                        break;
                    case "3":
                    case "add":
                        // add new customer
                        AddNewCustomer();
                        break;
                    case "4":
                    case "update":
                        // update customer
                        UpdateCustomer();
                        break;
                    case "5":
                    case "delete":
                        // delete customer
                        DeleteCustomer();
                        break;
                    case "6":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        ContinueMessage();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Ma salama!"); // transliteration of Arabic 'goodbye'
            Thread.Sleep(2000);
        }

        // return to main menu message
        private void ReturnToMainMessage()
        {
            Console.WriteLine("\nPress any key to return to the main Menu...");
            Console.ReadKey();
        }

        // continue message
        private void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // display customer
        public void DisplayCustomer(Customer customer)
        {
            Console.WriteLine($"{customer.FirstName}    {customer.LastName}     {customer.TypeOfCustomer}       {customer.Email}");
        }

        // display all customers
        private void DisplayAllCustomers()
        {
            Console.Clear();

            List<Customer> customers = _repo.GetCustomers();
            Console.WriteLine("First       Last        Type        Outgoing Message");

            foreach (Customer customer in customers)
            {
                DisplayCustomer(customer);
            }
            ReturnToMainMessage();
        }

        // show customers of type
        public void DisplayCustomersOfType()
        {
            Console.Clear();

            List<Customer> custOfType = new List<Customer>();
            Console.WriteLine("Enter customer type to view:\n" +
                "(current, past, or potential)");
            string type = Console.ReadLine();

            switch (type)
            {
                case "current":
                    custOfType =_repo.GetCustomersByType(Type.current);
                    break;
                case "past":
                    custOfType = _repo.GetCustomersByType(Type.past);
                    break;
                case "potential":
                    custOfType = _repo.GetCustomersByType(Type.potential);
                    break;
                default:
                    Console.WriteLine("Invalid type");
                    ReturnToMainMessage();
                    break;
            }

            Console.WriteLine("First       Last        Type        Outgoing Message");

            foreach (Customer customer in custOfType)
            {
                DisplayCustomer(customer);
            }        
            ReturnToMainMessage();
        }

        // add new customer
        public void AddNewCustomer()
        {
            Console.Clear();

            Customer customer = new Customer();

            // first name
            bool isValidFirstName = false;
            while (!isValidFirstName)
            {
                Console.WriteLine("First Name: ");
                string firstName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("Please enter a valid First Name");
                    ContinueMessage();
                }
                else
                {
                    customer.FirstName = firstName;
                    isValidFirstName = true;
                }
            }

            // last name
            bool isValidLastName = false;
            while (!isValidLastName)
            {
                Console.WriteLine("Last Name: ");
                string lastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Please enter a valid Last Name");
                    ContinueMessage();
                }
                else
                {
                    customer.LastName = lastName;
                    isValidLastName = true;
                }
            }

            // type
            Console.WriteLine("Customer type: \n" +
                "1. current\n" +
                "2. past\n" +
                "3. potential\n");

            string typeInput = Console.ReadLine().ToLower();

            switch (typeInput)
            {
                case "1":
                case "current":
                    customer.TypeOfCustomer = Type.current;
                    break;
                case "2":
                case "past":
                    customer.TypeOfCustomer = Type.past;
                    break;
                case "3":
                case "potential":
                    customer.TypeOfCustomer = Type.potential;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

            _repo.AddCustomerToDirectory(customer);
        }

        // update customer
        public void UpdateCustomer()
        {
            // get customer by name
            //  follow add new customer logic (don't add to repo though)
            //      call update repo method
            Console.Clear();
            Console.WriteLine("First and last name of the customer to update: ");
            string[] inputs = Console.ReadLine().Split();

            Customer customerToUpdate = _repo.GetCustomerByName(inputs[0], inputs[1]);
            if (customerToUpdate == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Console.WriteLine("First    Last     Type");
                DisplayCustomer(customerToUpdate);

                Console.WriteLine("\nEnter all new information for customer");
                Customer newCustomerInfo = new Customer();

                // first name
                bool isValidFirstName = false;
                while (!isValidFirstName)
                {
                    Console.WriteLine("First Name: ");
                    string firstName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("Please enter a valid First Name");
                        ContinueMessage();
                    }
                    else
                    {
                        newCustomerInfo.FirstName = firstName;
                        isValidFirstName = true;
                    }
                }

                // last name
                bool isValidLastName = false;
                while (!isValidLastName)
                {
                    Console.WriteLine("Last Name: ");
                    string lastName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Please enter a valid Last Name");
                        ContinueMessage();
                    }
                    else
                    {
                        newCustomerInfo.LastName = lastName;
                        isValidLastName = true;
                    }
                }

                // type
                Console.WriteLine("Customer type: \n" +
                    "1. current\n" +
                    "2. past\n" +
                    "3. potential\n");

                string typeInput = Console.ReadLine().ToLower();

                switch (typeInput)
                {
                    case "1":
                    case "current":
                        newCustomerInfo.TypeOfCustomer = Type.current;
                        break;
                    case "2":
                    case "past":
                        newCustomerInfo.TypeOfCustomer = Type.past;
                        break;
                    case "3":
                    case "potential":
                        newCustomerInfo.TypeOfCustomer = Type.potential;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }

                _repo.UpdateExistingCustomer(inputs[0], inputs[1], newCustomerInfo);
            }
            ReturnToMainMessage();
        }

        // delete customer
        public void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter the first and last name of the customer to remove: ");
            string[] inputs = Console.ReadLine().Split();

            Customer customerToRemove = _repo.GetCustomerByName(inputs[0], inputs[1]);
            if (customerToRemove == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                DisplayCustomer(customerToRemove);
                Console.WriteLine("Are you sure you want to remove this customer? (y/n)");

                string response = Console.ReadLine();
                if (response.ToLower() == "y" || response.ToLower() == "yes")
                {
                    _repo.DeleteExistingCustomer(customerToRemove);
                    Console.WriteLine($"{customerToRemove.FirstName} {customerToRemove.LastName} removed from database");
                }
                else
                {
                    Console.WriteLine("\nThis is no place for monkey business!");
                }
            }
            ReturnToMainMessage();
        }

    }
}
