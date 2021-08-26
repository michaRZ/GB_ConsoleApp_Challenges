using KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_Test
{
    [TestClass]
    public class Badge_Tests
    {
        [TestMethod]
        public void BadgeTest()
        {
            Badge badge1 = new Badge(12345, new List<string> { "R2", "D2" });
            string doorsString = string.Join(",", badge1.AccessDoors);
            Console.WriteLine(badge1.BadgeID + " " + doorsString);

            Badge badge2 = new Badge(12341);
            Assert.AreEqual(12341, badge2.BadgeID);
        }
    }
}
