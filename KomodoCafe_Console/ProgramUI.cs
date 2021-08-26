using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            MenuItem mi1 = new MenuItem(1, "Fried chicken sandwich", "crispy fried chicken served with ketchup and pickles on a toasted bun", new List<string> { "bun", "fried chicken", "pickle", "ketchup" }, 5.29m);
            MenuItem mi2 = new MenuItem(2, "Fried chicken sandwich meal", "fried chicken sandwich, served with fries", new List<string> { "bun", "fried chicken", "pickle", "ketchup", "fries" }, 7.49m);
            MenuItem mi3 = new MenuItem(3, "Spicy chicken sandwich", "fried spicy chicken served with mayo and cheese on a toasted bun", new List<string> { "bun", "spicy chicken", "cheese", "mayo" }, 5.49m);
            MenuItem mi4 = new MenuItem(4, "Spicy chicken sandwich meal", "spicy chicken sandwich, served with fries", new List<string> { "bun", "spicy chicken", "cheese", "mayo", "fries" }, 7.69m);

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
                string title = @"
   _   _   _   _   _   _   _   _   _   _   _   _   _   _   _  
  / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ / \ 
 ( C ( h ( i ( c ( k ( - ( f ( i ( l ( - ( A ( Y ( Y ( Y ( ! )
  \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ \_/ 
";
                Console.WriteLine(title);

                Console.WriteLine("Manager options:\n" +
                    "1. Show full menu\n" +
                    "2. Search menu by item name\n" +
                    "3. Search menu by item number\n" +
                    "4. Add new item to menu\n" +
                    "5. Delete menu item\n" +
                    "6. Exit\n");

                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "menu":
                        // Show full menu
                        ShowFullMenu();
                        break;
                    case "2":
                    case "name":
                        // Search menu by name
                        ShowItemByName();
                        break;
                    case "3":
                    case "number":
                        // Show item by number
                        ShowItemByNumber();
                        break;
                    case "4":
                    case "add":
                        // add new menu item
                        AddItemToMenu();
                        break;
                    case "5":
                    case "delete":
                        // delete menu item
                        DeleteItemFromMenu();
                        break;
                    case "6":
                    case "exit":
                        // exit application
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        ContinueMessage();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("It's been our pleasure...\n\n" +
                "Best wishes! Goodbye!");
            Thread.Sleep(2500);
        }

        // display items DRY code
        private void DisplayItem(MenuItem item)
        {
            Console.WriteLine($"The #{item.MealNumber}. {item.Name} - {item.Description} - ${item.Price}");
            Console.Write("        -Ingredients: ");
            item.Ingredients.ForEach(addedIngredient => Console.Write(addedIngredient + ", "));
            Console.WriteLine("\n");
        }

        // return to main menu message
        private void ReturnToMainMessage()
        {
            Console.WriteLine("\nPress any key to return to the Options Menu...");
            Console.ReadKey();
        }

        // continue message
        private void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // show full menu
        private void ShowFullMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetFullMenu();
            foreach (MenuItem item in fullMenu)
            {
                DisplayItem(item);
            }
            ReturnToMainMessage();
        }

        // search menu by item name
        private void ShowItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter menu item name: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            MenuItem item = _repo.GetItemByName(name);

            if (item == null)
            {
                Console.WriteLine("Menu item not found");
            }
            else
                DisplayItem(item);

            ReturnToMainMessage();
        }

        // search menu by item number
        private void ShowItemByNumber()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetFullMenu();
            Console.WriteLine($"Enter menu item number between 1-{fullMenu.Count}: ");
            string numString = Console.ReadLine();
            int numInt;

            if (int.TryParse(numString, out numInt))
            {
                if (numInt < 1 || numInt > fullMenu.Count)
                {
                    Console.WriteLine("Menu item not found");
                }
                else
                {
                    MenuItem item = _repo.GetItemByNumber(numInt);
                    DisplayItem(item);
                }
            }
            else
            {
                Console.WriteLine("Menu item not found");
            }
            ReturnToMainMessage();
        }

        // add new item to menu
        private void AddItemToMenu()
        {
            Console.Clear();
            List<MenuItem> fullMenu = _repo.GetFullMenu();
            MenuItem item = new MenuItem();

            // set item number
            bool isValidNumber = false;
            while (!isValidNumber)
            {
                Console.WriteLine("Menu Item Number: ");
                string numString = Console.ReadLine();
                int numInt;

                if (!int.TryParse(numString, out numInt))
                {
                    Console.WriteLine("\nPlease enter a valid item number");
                }
                else if (numInt <= fullMenu.Count)
                {
                    Console.WriteLine("Menu Item number already exists as: ");
                    MenuItem existingItem = _repo.GetItemByNumber(numInt);
                    DisplayItem(existingItem);

                    Console.WriteLine("\nPlease, please enter a valid item number");
                }
                else
                {
                    item.MealNumber = numInt;
                    isValidNumber = true;
                }
            }

            // set item name
            bool isValidName = false;
            while (!isValidName)
            {
                Console.WriteLine("\nMenu Item Name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Please enter a valid item name");
                    // ContinueMessage();
                }
                else
                {
                    item.Name = name;
                    isValidName = true;
                }
            }

            // set item description
            Console.WriteLine("\nMenu Item Description: ");
            string description = Console.ReadLine();
            item.Description = string.IsNullOrWhiteSpace(description) ? "(No description)" : description;

            // set item ingredients
            List<string> ingredients = new List<string>();

            bool noMoreIngredients = false;
            while (!noMoreIngredients)
            {
                Console.WriteLine("\nMenu Item ingredients: ");

                string ingredient = Console.ReadLine();
                ingredients.Add(ingredient);

                Console.Write("\nSelected ingredients: ");
                ingredients.ForEach(addedIngredient => Console.Write(addedIngredient + ", "));

                Console.WriteLine("\nAdd another ingredient? (y/n)");
                string response = Console.ReadLine().ToLower();
                if (response == "n" || response == "no")
                {
                    item.Ingredients = ingredients;
                    noMoreIngredients = true;
                }
            }

            // set item price
            bool isValidPrice = false;
            while (!isValidPrice)
            {
                Console.WriteLine("\nMenu Item Price: ");
                string priceString = Console.ReadLine();
                decimal priceDecimal;

                if (!decimal.TryParse(priceString, out priceDecimal))
                {
                    Console.WriteLine("Please enter a valid price");
                }
                else
                {
                    // decimal price = decimal.Parse(Console.ReadLine());
                    item.Price = priceDecimal;
                    isValidPrice = true;
                }
            }

            _repo.AddItemToMenu(item);
        }

        // delete item from menu
        private void DeleteItemFromMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the NAME of the Menu Item to remove: \n");
            List<MenuItem> fullMenu = _repo.GetFullMenu();
            foreach (MenuItem option in fullMenu)
            {
                DisplayItem(option);
            }
            Console.WriteLine();
            string name = Console.ReadLine();

            MenuItem item = _repo.GetItemByName(name);

            if (item == null)
            {
                Console.WriteLine("Menu item not found");
            }
            else
            {
                DisplayItem(item);
                Console.WriteLine("Are you sure you want to remove this from the menu? (y/n)");

                string response = Console.ReadLine();
                if (response.ToLower() == "y" || response.ToLower() == "yes")
                {
                    _repo.DeleteMenuItem(item);
                    Console.WriteLine($"#{item.MealNumber}. {item.Name} removed from menu");
                }
                else
                {
                    Console.WriteLine("\nYou know, you really shouldn't play around here");
                }
            }
            ReturnToMainMessage();
        }
    }
}
