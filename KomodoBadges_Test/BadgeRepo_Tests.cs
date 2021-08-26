using KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_Test
{
    [TestClass]
    public class BadgeRepo_Tests
    {
        BadgeRepository _repo = new BadgeRepository();
        Badge testBadge = new Badge(90210, new List<string> { "C3", "P0" });


        [TestMethod]
        public void AddBadgeToDictionary_ShouldAddBadge()
        {
            BadgeRepository repo = new BadgeRepository();
            Badge badge1 = new Badge(8675309);
            badge1.AccessDoors = new List<string> { "FN, 21, 87" };

            bool wasAdded = repo.AddBadgeToDictionary(badge1);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetDictionary_ShouldReturnAllBadges()
        {
            _repo.AddBadgeToDictionary(testBadge);
            Dictionary<int, List<string>> testDict = _repo.GetDictionary();

            bool wasReturned = testDict.ContainsKey(testBadge.BadgeID);

            Assert.IsTrue(wasReturned);
        }

        [TestMethod]
        public void GetBadgeByNumber_ShouldReturnCorrectBadge() // passes only when run individually - why?
        {
            _repo.AddBadgeToDictionary(testBadge);
            int badgeNumber = testBadge.BadgeID;

            Badge retrievedBadge = _repo.GetBadgeByNumber(badgeNumber);

            Assert.AreEqual(retrievedBadge.BadgeID, testBadge.BadgeID);
        }


        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()  // passes only when run individually - why?
        {
            _repo.AddBadgeToDictionary(testBadge);
            Badge newInfo = new Badge(90210, new List<string> {"R2", "D2"});

            bool isUpdated = _repo.UpdateExistingBadge(testBadge.BadgeID, newInfo);

            Assert.IsTrue(isUpdated);
        }

        // does test order matter?
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            Badge deleteThis = new Badge(731);
            _repo.AddBadgeToDictionary(deleteThis);

            bool wasDeleted = _repo.DeleteBadge(deleteThis);
            Assert.IsTrue(wasDeleted);
        }
    }
}
