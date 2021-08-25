using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuItem
    {
        // CONSTRUCTORS

        // empty - for tests
        public MenuItem() { }

        public MenuItem(int mealNumber, string name, string description, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }




        // PROPERTIES
        
        public int MealNumber { get; set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value.ToUpper();
            }
        }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public decimal Price { get; set; }
    }


    // Available meal igredients from store inventory
    //public enum Inventory { bun, GF_bun, grilled_Chicken, fried_Chicken, spicy_Chicken, bacon, cheese, lettuce, tomato, pickle, ketchup, mustard, mayo, fries, salad, fruit }

}
