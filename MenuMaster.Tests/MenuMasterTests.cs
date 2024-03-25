using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Menu;

namespace MenuMasterTests
{
    [TestClass]
    public class MenuMasterTests
    {//
        private MenuMaster menuMaster;

        [TestInitialize]
        public void Initialize()
        {
            List<string> menuItems = new List<string> { "Матча", "Латте", "Смузи", "Джин", "Эскимо" };
            int itemsPerPage = 2;
            menuMaster = new MenuMaster(menuItems, itemsPerPage);
        }

        [TestMethod]
        public void GetTotalCountFood()
        {
            int expectedCount = 5;
            int actualCount = menuMaster.GetTotalCountFood();
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetTotalPagesCount()
        {
            int expectedPages = 3;
            int actualPages = menuMaster.GetTotalPagesCount();
            Assert.AreEqual(expectedPages, actualPages);
        }

        [TestMethod]
        public void GetCountFoodOnPage()
        {
            int pageNumber = 2;
            int expectedCount = 2;
            int actualCount = menuMaster.GetCountFoodOnPage(pageNumber);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetFoodOnPage()
        {
            int pageNumber = 2;
            List<string> expectedFood = new List<string> { "Смузи", "Джин" };
            List<string> actualFood = menuMaster.GetFoodOnPage(pageNumber);
            CollectionAssert.AreEqual(expectedFood, actualFood);
        }

        [TestMethod]
        public void GetFirstFoodOnAllPages()
        {
            List<string> expectedFirstFood = new List<string> { "Матча", "Смузи", "Эскимо" };
            List<string> actualFirstFood = menuMaster.GetFirstFoodOnAllPages();
            CollectionAssert.AreEqual(expectedFirstFood, actualFirstFood);
        }
    }
}