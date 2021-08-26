using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetings_Repository
{
    public class CustomerRepository
    {
        protected readonly List<Customer> _customerDirectory = new List<Customer>();


        // CREATE
        public bool AddCustomerToDirectory(Customer customer)
        {
            int startingCount = _customerDirectory.Count;

            _customerDirectory.Add(customer); 

            bool wasAdded = _customerDirectory.Count > startingCount; 
            return wasAdded;
        }


        // READ
        // get full list of customers
        public List<Customer> GetCustomers()
        {
            return _customerDirectory;
        }

        // get customers alphabetically
        public List<Customer> GetCustomersAlphabetically()
        {
            List<Customer> customers = GetCustomers();
            List<Customer> sortedDirectory = new List<Customer>(); 

            sortedDirectory = customers.OrderBy(x => x).ToList();
            return sortedDirectory;
        }

        // get customer by matching exact name
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if (customer.FirstName == firstName.ToUpper() && customer.LastName == lastName.ToUpper())
                {
                    return customer;
                }
            }
            return null;
        }

        // return only customers of an input type
        public List<Customer> GetCustomersByType(Type type)
        {
            List<Customer> customers = GetCustomers(); 
            List<Customer> listByType = new List<Customer>(); 

            foreach (Customer customer in customers)
            {
                if (type == customer.TypeOfCustomer)
                {
                    listByType.Add(customer); 
                }
            }
            return listByType;
        }


        // UPDATE
        public bool UpdateExistingCustomer(string firstName, string lastName, Customer newInfo)
        {
            Customer oldInfo = GetCustomerByName(firstName, lastName);

            if (oldInfo != null)
            {
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.TypeOfCustomer = newInfo.TypeOfCustomer;

                return true;
            }
            else
            {
                return false;
            }
        }


        // DELETE
        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _customerDirectory.Remove(existingCustomer);
            return deleteResult;
        }
    }
}
