using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Badges_Test
{
    [TestClass]
    public class BadgesTest
    {
        [TestMethod]
        public void AddToBadges_ShouldGetCorrectBoolean()
        {
            Badge newBadge = new Badge();
            BadgeRepo repo = new BadgeRepo();
            bool addResult = repo.AddBadge(newBadge);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectCollection()
        {
            Badge testBadge = new Badge(4688, new List<string> { "A4", "A7" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadge(testBadge);
            Dictionary<int,Badge> badges = repo.GetBadges();
            bool hasBadges = badges.ContainsKey(testBadge.BadgeID);
            Assert.IsTrue(hasBadges);
        }
    }
}
