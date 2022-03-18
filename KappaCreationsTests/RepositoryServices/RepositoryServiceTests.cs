using KappaCreations.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace KappaCreations.RepositoryServices.Tests
{
    [TestClass()]
    public class RepositoryServiceTests
    {
        [TestMethod()]
        public void RepositoryServiceTest()
        {
            var repo = new RepositoryService<Text>();
            var text = new Text()
            {
                Colour = new Colour("#FFFFFF"),
                Position = new Position(10, 10, 1),
                Size = new Size(20),
                Content = "Test",
                Font = new Font() { Name = "TestFont" },
            };
            repo.Add(text);
        }

        [TestMethod()]
        public void RepositoryServiceTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteAsyncTest1()
        {
            Assert.Fail();
        }
    }
}