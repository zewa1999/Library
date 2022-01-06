using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Library.DomainLayer.Tests
{
    [TestClass]
    public class EditionTests
    {
        private Edition edition;

        [TestInitialize]
        public void Initialize()
        {
            edition = new();
        }

        [TestMethod]
        public void PublisherShouldHaveLessThanFiftyChars()
        {
            var publisher = new string('a', 49);
            edition.Publisher = publisher;

            Assert.IsTrue(edition.Publisher.Length <= 50);
        }

        [TestMethod]
        public void PublisherShouldHaveMoreThanFiftyChars()
        {
            var publisher = new string('a', 52);
            edition.Publisher = publisher;

            Assert.IsTrue(edition.Publisher.Length > 50);
        }

        [TestMethod]
        public void YearShouldHaveLessThan4Chars()
        {
            var year = new string('a', 4);
            edition.Year = year;

            Assert.IsTrue(edition.Year.Length <= 4);
        }

        [TestMethod]
        public void YearShouldHaveOnlyNumbers()
        {
            edition.Year = "1234";

            Assert.IsTrue(edition.Year.All(char.IsDigit));
        }

        [TestMethod]
        public void EditionNumberShouldBeLessThanFifty()
        {
            edition.EditionNumber = 23;

            Assert.IsTrue(edition.EditionNumber <  50);
        }

        [TestMethod]
        public void EditionNumberShouldNotBeNegative()
        {
            edition.EditionNumber = -4;

            Assert.IsTrue(edition.EditionNumber < 0);
        }

        [TestMethod]
        public void NumberOfPagesShouldNotBeNegative()
        {
            edition.NumberOfPages = -4;

            Assert.IsTrue(edition.NumberOfPages < 0);
        }
    }
}
