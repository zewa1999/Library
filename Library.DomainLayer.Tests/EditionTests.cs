// <copyright file="EditionTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class EditionTests
    {
        private Edition edition;

        [TestInitialize]
        public void Initialize()
        {
            this.edition = new();
        }

        [TestMethod]
        public void PublisherShouldHaveLessThanFiftyChars()
        {
            var publisher = new string('a', 49);
            this.edition.Publisher = publisher;

            Assert.IsTrue(this.edition.Publisher.Length <= 50);
        }

        [TestMethod]
        public void PublisherShouldHaveMoreThanFiftyChars()
        {
            var publisher = new string('a', 52);
            this.edition.Publisher = publisher;

            Assert.IsTrue(this.edition.Publisher.Length > 50);
        }

        [TestMethod]
        public void YearShouldHaveLessThan4Chars()
        {
            var year = new string('a', 4);
            this.edition.Year = year;

            Assert.IsTrue(this.edition.Year.Length <= 4);
        }

        [TestMethod]
        public void YearShouldHaveOnlyNumbers()
        {
            this.edition.Year = "1234";

            Assert.IsTrue(this.edition.Year.All(char.IsDigit));
        }

        [TestMethod]
        public void EditionNumberShouldBeLessThanFifty()
        {
            this.edition.EditionNumber = 23;

            Assert.IsTrue(this.edition.EditionNumber < 50);
        }

        [TestMethod]
        public void EditionNumberShouldNotBeNegative()
        {
            this.edition.EditionNumber = -4;

            Assert.IsTrue(this.edition.EditionNumber < 0);
        }

        [TestMethod]
        public void NumberOfPagesShouldNotBeNegative()
        {
            this.edition.NumberOfPages = -4;

            Assert.IsTrue(this.edition.NumberOfPages < 0);
        }
    }
}