using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            Menu newMenuItem = new Menu();
            MenuRepo repo = new MenuRepo();

            bool addResult = repo.AddItemToMenu(newMenuItem);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetFullMenu_ShouldReturnCorrectCollection()
        {
            Menu testMenu = new Menu(1, "Big Mac", "over 14 billion sold", "hamburger, onion, lettuce, pickle, tomato", 3.95);
            MenuRepo repo = new MenuRepo();
            repo.AddItemToMenu(testMenu);
            List<Menu> menu = repo.GetMenu();
            bool hasMenu = menu.Contains(testMenu);
            Assert.IsTrue(hasMenu);
        }
        private Menu _content;
        private MenuRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _content = new Menu(1, "Big Mac", "over 14 billion sold", "hamburger, onion, lettuce, pickle, tomato", 3.95);
            _repo.AddItemToMenu(_content);

        }

        [TestMethod]
        public void RemoveAClaim_ShouldReturnTrue()
        {
            Menu foundMenu = _content;
            bool removeMenu = _repo.DeleteMenuItem(foundMenu);
            Assert.IsTrue(removeMenu);
        }
    }
}
