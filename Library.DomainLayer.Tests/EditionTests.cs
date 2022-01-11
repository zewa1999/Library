// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="EditionTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class EditionTests.
    /// </summary>
    [TestClass]
    public class EditionTests
    {
        /// <summary>
        /// The edition.
        /// </summary>
        private Edition edition;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.edition = new ();
        }

        /// <summary>
        /// Defines the test method PublisherShouldHaveLessThanFiftyChars.
        /// </summary>
        [TestMethod]
        public void PublisherShouldHaveLessThanFiftyChars()
        {
            var publisher = new string('a', 49);
            this.edition.Publisher = publisher;

            Assert.IsTrue(this.edition.Publisher.Length <= 50);
        }

        /// <summary>
        /// Defines the test method PublisherShouldHaveMoreThanFiftyChars.
        /// </summary>
        [TestMethod]
        public void PublisherShouldHaveMoreThanFiftyChars()
        {
            var publisher = new string('a', 52);
            this.edition.Publisher = publisher;

            Assert.IsTrue(this.edition.Publisher.Length > 50);
        }

        /// <summary>
        /// Defines the test method YearShouldHaveLessThan4Chars.
        /// </summary>
        [TestMethod]
        public void YearShouldHaveLessThan4Chars()
        {
            var year = new string('a', 4);
            this.edition.Year = year;

            Assert.IsTrue(this.edition.Year.Length <= 4);
        }

        /// <summary>
        /// Defines the test method YearShouldHaveOnlyNumbers.
        /// </summary>
        [TestMethod]
        public void YearShouldHaveOnlyNumbers()
        {
            this.edition.Year = "1234";

            Assert.IsTrue(this.edition.Year.All(char.IsDigit));
        }

        /// <summary>
        /// Defines the test method EditionNumberShouldBeLessThanFifty.
        /// </summary>
        [TestMethod]
        public void EditionNumberShouldBeLessThanFifty()
        {
            this.edition.EditionNumber = 23;

            Assert.IsTrue(this.edition.EditionNumber < 50);
        }

        /// <summary>
        /// Defines the test method EditionNumberShouldNotBeNegative.
        /// </summary>
        [TestMethod]
        public void EditionNumberShouldNotBeNegative()
        {
            this.edition.EditionNumber = -4;

            Assert.IsTrue(this.edition.EditionNumber < 0);
        }

        /// <summary>
        /// Defines the test method NumberOfPagesShouldNotBeNegative.
        /// </summary>
        [TestMethod]
        public void NumberOfPagesShouldNotBeNegative()
        {
            this.edition.NumberOfPages = -4;

            Assert.IsTrue(this.edition.NumberOfPages < 0);
        }
    }
}