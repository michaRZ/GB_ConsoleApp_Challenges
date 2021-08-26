using KomodoGreetings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoGreetings_Tests
{
    [TestClass]
    public class CustomerRepo_Tests
    {
        // field for tests to refer to CustomerRepository
        private CustomerRepository _repo;
        private Customer _customer = new Customer("Ross", "Gellar", Type.potential);

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CustomerRepository();

            _repo.AddCustomerToDirectory(_customer);
        }

        [TestMethod]
        public void AddCustomer_ShouldReturnTrue()
        {
            Customer customer = new Customer("Monica", "Gellar", Type.potential);
            bool addResult = _repo.AddCustomerToDirectory(customer);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetCustomers_ShouldReturnCorrectCollection()
        {
            CustomerRepository repo = new CustomerRepository();
            Customer customer = new Customer("Joey", "Tribbiani", Type.potential);
            repo.AddCustomerToDirectory(customer);

            List<Customer> customers = repo.GetCustomers();

            bool directoryHasCustomers = customers.Contains(customer);

            Assert.IsTrue(directoryHasCustomers);
        }

        [TestMethod]
        public void GetCustomersAlphabetically_ShouldPrintInOrder()     // FAILS
        {
            CustomerRepository repo = new CustomerRepository();
            Customer c1 = new Customer("Pheobe", "Buffay", Type.current);
            Customer c2 = new Customer("Chandler", "Bing", Type.current);
            Customer c3 = new Customer("Rachel", "Green", Type.potential);

            repo.AddCustomerToDirectory(c1);
            repo.AddCustomerToDirectory(c2);
            repo.AddCustomerToDirectory(c3);

            List<Customer> customers = repo.GetCustomersAlphabetically();

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }
        }

        [TestMethod]
        public void GetCustomerByName_ShouldGetCorrectCustomers()
        {
            Customer customer = _repo.GetCustomerByName("ross", "gellar");
            Assert.AreEqual(_customer, customer);
        }

        [TestMethod]
        public void GetCustomersByType_()
        {
            Customer c1 = new Customer("Pheobe", "Buffay", Type.past);
            Customer c2 = new Customer("Chandler", "Bing", Type.current);
            Customer c3 = new Customer("Rachel", "Green", Type.potential);
            Customer c4 = new Customer("Janice", "Litman", Type.current);

            _repo.AddCustomerToDirectory(c1);
            _repo.AddCustomerToDirectory(c2);
            _repo.AddCustomerToDirectory(c3);
            _repo.AddCustomerToDirectory(c4);

            List<Customer> currentCustomers = _repo.GetCustomersByType(Type.current);

            Assert.AreEqual(2, currentCustomers.Count);
        }

        [TestMethod]
        public void UpdateExistingCustomer_ShouldUpdate()
        {
            Customer newCustomerInfo = new Customer("Ross", "Gellar", Type.past);
            _repo.UpdateExistingCustomer("Ross", "Gellar", newCustomerInfo);

            var expected = Type.past;
            var actual = _customer.TypeOfCustomer;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteExistingCustomer_ShouldDelete()
        {
            Customer customer = new Customer("Tag", "Jones", Type.past);

            bool wasAdded = _repo.AddCustomerToDirectory(customer);
            Assert.IsTrue(wasAdded);

            bool customerDeleted = _repo.DeleteExistingCustomer(customer);
            Assert.IsTrue(customerDeleted);
        }
    }
}
