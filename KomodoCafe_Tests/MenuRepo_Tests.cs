using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class MenuRepo_Tests
    {

        // preset fields for test methods to reference
        private MenuRepository _repo = new MenuRepository();
        private MenuItem _menuItem = new MenuItem(1, "Grilled chicken sandwich meal", "grilled chicken sandwich with fries",
            new List<string> {"bun", "grilled chicken", "pickles", "fries" }, 8.49m);

        [TestInitialize]
        public void Arrange()
        {
            _repo.AddItemToMenu(_menuItem);
        }


        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            // AAA
            MenuItem menuItem = new MenuItem();
            menuItem.MealNumber = 2;
            menuItem.Name = "Spicy chicken sandwich meal";

            bool wasAdded = _repo.AddItemToMenu(menuItem);

            Assert.IsTrue(wasAdded);
        }


        [TestMethod]
        public void GetMenu_ShouldReturnAllMenuItems()
        {
            List<MenuItem> allItems = _repo.GetFullMenu();

            Assert.AreEqual(1, allItems.Count);
        }


        [TestMethod]
        public void GetItemByNumber_ShouldBeMatchingItem()
        {
            MenuItem menuItem = _repo.GetItemByNumber(1);

            Assert.AreEqual(_menuItem, menuItem);
        }


        [TestMethod]
        public void GetItemByName_ShouldBeMatchingItem()
        {
            MenuItem menuItem = _repo.GetItemByName("grilled chicken sandwich meal");

            Assert.AreEqual(_menuItem, menuItem);
        }


        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            MenuItem item2 = new MenuItem(3, "Fried chicken sandwich", "crispy breaded sandwich served on a bun with pickles and ketchup, sandwich only",
                new List<string> { "bun", "fried chicken", "pickle", "ketchup" }, 5.29m);

            bool wasAdded = _repo.AddItemToMenu(item2);
            Assert.IsTrue(wasAdded);

            bool itemDeleted = _repo.DeleteMenuItem(item2);
            Assert.IsTrue(itemDeleted);
        }
    }
}
