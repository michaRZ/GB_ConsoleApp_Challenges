using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgeRepository
    {
        private List<Badge> _badges = new List<Badge>();
        public Dictionary<int, string> _secDictionary = new Dictionary<int, string>();


        // CREATE
        public bool AddBadgeToList(Badge badge)
        {
            int startingCount = _badges.Count;

            _badges.Add(badge);

            bool wasAdded = _badges.Count > startingCount;
            return wasAdded;
        }

        // READ
        public Dictionary<int, string> GetDictionary()
        {          
            foreach (Badge employee in _badges)
            {
                string doorsString = string.Join(",", _badges);
                _secDictionary.Add(employee.BadgeID, doorsString);
            }
            return _secDictionary;
        }

        public Badge GetBadgeByNumber(int number)
        {
            foreach (Badge employee in _badges)
            {
                if (employee.BadgeID == number)
                {
                    return employee;
                }
            }
            return null;
        }


        /* - not sure if these are needed
        // UPDATE
        public bool AddAccessDoor()
        {


        }


        // DELETE/UPDATE (not deleting instances of badge, only deleting AccessDoors
        public bool DeleteAccessDoor(int number, string door)
        {
            if (_secDictionary.ContainsKey(number))
            {
                _secDictionary.Remove(door);
            }
            bool wasDeleted = ; 
            return wasDeleted;
        }
        */

    }
}
