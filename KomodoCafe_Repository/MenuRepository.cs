using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuRepository
    {
        // CR-D methods
        // Update not necessary currently

        // Reference repo
        private readonly List<MenuItem> _menu = new List<MenuItem>();


        // CREATE
        public bool AddItemToMenu(MenuItem item)
        {
            int startingCount = _menu.Count;

            _menu.Add(item);

            bool wasAdded = _menu.Count > startingCount;
            return wasAdded;
        }


        // READ
        // consider adding methods for getting list of menu items with certain ingredients, ie gf bun or spicy chicken
        public List<MenuItem> GetFullMenu()
        {
            return _menu;
        }

        public MenuItem GetItemByNumber(int number)
        {
            foreach (MenuItem item in _menu)
            {
                if (item.MealNumber == number)
                {
                    return item;
                }
            }
            return null;
        }

        public MenuItem GetItemByName(string name)
        {
            name = name.ToUpper();

            foreach (MenuItem item in _menu)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }


        // UPDATE
        // not needed for current project


        // DELETE
        public bool DeleteMenuItem(MenuItem item)
        {
            bool wasDeleted = _menu.Remove(item);
            return wasDeleted;
        }
    }
}