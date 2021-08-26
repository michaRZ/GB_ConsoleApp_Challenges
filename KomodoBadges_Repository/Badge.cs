using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class Badge
    {
        // CONSTRUCTORS
        public Badge() { }
        public Badge(int badgeID)
        {
            BadgeID = badgeID;
        }
        public Badge(int badgeID, List<string> accessDoors)
        {
            BadgeID = badgeID;
            AccessDoors = accessDoors;
        }



        // PROPERTIES
        public int BadgeID { get; set; }
        public List<string> AccessDoors { get; set; }
    }
}
