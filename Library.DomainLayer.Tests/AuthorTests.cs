// <copyright file="AuthorTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class AuthorTests
    {
        private Author author;

        [TestInitialize]
        public void Initialize()
        {
            this.author = new();
        }

        [TestMethod]
        public void AuthorIdShouldBeValid()
        {
            this.author.Id = 1;
            Assert.AreEqual(1, this.author.Id);
        }

        [TestMethod]
        public void LastNameShouldBeValid()
        {
            this.author.LastName = "Costache";
            bool isIntString = this.author.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            this.author.LastName = "Costache123";
            bool isIntString = this.author.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            this.author.FirstName = "Stelian";
            bool isIntString = this.author.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            this.author.FirstName = "1223Andrei";
            bool isIntString = this.author.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }
    }
}