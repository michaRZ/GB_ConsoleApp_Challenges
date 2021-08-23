using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuItem_Tests
    {
        [TestMethod]
        public void MenuItemTest()
        {
            MenuItem item1 = new MenuItem(1, "Tester", "a delicious Test MenuItem, just like mom used to make",
                new List<Inventory> { Inventory.GF_bun, Inventory.spicy_Chicken, Inventory.cheese, Inventory.lettuce, Inventory.tomato, Inventory.pickle, Inventory.fries },
                7.49m);
            Console.WriteLine($"The #{item1.MealNumber} is our {item1.Name} meal. It is {item1.Description}, and costs ${item1.Price}.");
        }
    }
}
