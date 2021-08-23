using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    public class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedItems();
            Options();
        }


        private void SeedItems()
        {
            Console.WriteLine("Seeding menu items...");

            MenuItem mi1 = new MenuItem(1, "Fried chicken sandwich", "crispy fried chicken served with ketchup and pickles on a toasted bun", new List<Inventory> { Inventory.bun, Inventory.fried_Chicken, Inventory.pickle, Inventory.ketchup }, 5.29m);
            MenuItem mi2 = new MenuItem(2, "Fried chicken sandwich meal", "fried chicken sandwich, served with fries", new List<Inventory> { Inventory.bun, Inventory.fried_Chicken, Inventory.pickle, Inventory.ketchup, Inventory.fries }, 7.49m);
            MenuItem mi3 = new MenuItem(3, "Spicy chicken sandwich", "fried spicy chicken served with mayo and cheese on a toasted bun", new List<Inventory> { Inventory.bun, Inventory.spicy_Chicken, Inventory.cheese, Inventory.mayo }, 5.49m);
            MenuItem mi4 = new MenuItem(4, "Spicy chicken sandwich meal", "spicy chicken sandwich, served with fries", new List<Inventory> { Inventory.bun, Inventory.spicy_Chicken, Inventory.cheese, Inventory.mayo, Inventory.fries }, 7.69m);

            _repo.AddItemToMenu(mi1);
            _repo.AddItemToMenu(mi2);
            _repo.AddItemToMenu(mi3);
            _repo.AddItemToMenu(mi4);
        }


        private void Options()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Manager options:\n" +
                    "1. Show full menu\n" +
                    "2. Search menu by item name or number\n" +
                    "3. Add new item to menu\n" +
                    "4. Delete menu item\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();
            }
        }
    }
}
