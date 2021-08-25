using KomodoBadges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadges_Test
{
    [TestClass]
    public class BadgeRepo_Tests
    {
        private BadgeRepository _repo = new BadgeRepository();
        private Badge _testBadge = new Badge(123456, new List<string> { "C3", "P0" });
        private Dictionary<string, List<string>> _testDictionary = new Dictionary<string, List<string>>();

        [TestMethod]
        public void Arrange()
        {
            _repo.AddBadgeToList(_testBadge);
        }

        [TestMethod]
        public void AddBadgeToList_ShouldAddBadge()
        {
            Badge badge = new Badge();
            badge.AccessDoors = new List<string> { "FN, 21, 87" };

            bool wasAdded = _repo.AddBadgeToList(badge);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetDictionary_ShouldReturnDictionary()
        {
            var test = _repo.GetDictionary();

            foreach (var kvp in test) Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        }
    }
}
