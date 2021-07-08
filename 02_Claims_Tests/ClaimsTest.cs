using _02_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            Claim newClaim = new Claim();
            ClaimRepo repo = new ClaimRepo();
            bool addResult = repo.AddClaim(newClaim);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectCollection()
        {
            Claim testClaim = new Claim(6482, ClaimType.Car, "Car runs into wall", 5000, Convert.ToDateTime("2020,5,15"), Convert.ToDateTime("2020/6/5"));
            ClaimRepo repo = new ClaimRepo();
            repo.AddClaim(testClaim);
            List<Claim> claims = repo.GetClaims();
            bool hasClaims = claims.Contains(testClaim);
            Assert.IsTrue(hasClaims);
        }
        private Claim _content;
        private ClaimRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            _content = new Claim(6482, ClaimType.Car, "Car runs into wall", 5000, Convert.ToDateTime("2020,5,15"), Convert.ToDateTime("2020/6/5"));
            _repo.AddClaim(_content);

        }
        [TestMethod]
        public void RemoveAClaim_ShouldReturnTrue()
        {
            Claim foundClaim = _content;
            bool removeClaim = _repo.RemoveClaim(foundClaim);
            Assert.IsTrue(removeClaim);
        }
    }
}
