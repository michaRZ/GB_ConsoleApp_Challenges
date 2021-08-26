using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{

    public class BadgeRepository
    {
        // private List<Badge> _repo = new List<Badge>(); - unused

        private static Dictionary<int, List<string>> _badgeDict = new Dictionary<int, List<string>>();


        // CREATE
        public bool AddBadgeToDictionary(Badge badge)
        {
            int startingCount = _badgeDict.Count;

            _badgeDict.Add(badge.BadgeID, badge.AccessDoors);
            
            bool wasAdded = _badgeDict.Count > startingCount;
            return wasAdded;
        }

        // READ
        public Dictionary<int, List<string>> GetDictionary()
        {
            return _badgeDict;
        }

        public Badge GetBadgeByNumber(int number)
        {
            if (_badgeDict.ContainsKey(number))
            {
                Badge badge = new Badge(number);    // utilise single param constructor
                badge.AccessDoors = _badgeDict[number];     // pull associated values w/ key 'number'
                return badge;
            }
            return null;
        }

        // UPDATE
        public bool UpdateExistingBadge(int idNum, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByNumber(idNum);
            
            if (_badgeDict.ContainsKey(idNum))
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.AccessDoors = newBadge.AccessDoors;
                return true;
            }
            else
            {
                return false;
            }
        }

        // DELETE - deleting instance of badge in dictionary, NOT deleting doors
        // won't be used in actual Console App
        public bool DeleteBadge(Badge badge)
        {
            bool wasDeleted = _badgeDict.Remove(badge.BadgeID);
            return wasDeleted;
        }
    }
}
