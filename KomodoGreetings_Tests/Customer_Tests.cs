using KomodoGreetings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoGreetings_Tests
{
    [TestClass]
    public class Customer_Tests
    {
        [TestMethod]
        public void ConstructCustomer_ShouldPrintCorrectValues()
        {
            Customer customer = new Customer("Regina", "Phalange", Type.potential);
            Console.WriteLine($"{customer.FirstName} {customer.LastName} is a {customer.TypeOfCustomer} customer. Send this message: \"{customer.Email}\"");
        }
    }
}
