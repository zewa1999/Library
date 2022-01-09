using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Library.DomainLayer.Tests
{
    [TestClass]
    public class AuthorTests
    {
        private Author author;

        [TestInitialize]
        public void Initialize()
        {
            author = new();
        }

        [TestMethod]
        public void AuthorIdShouldBeValid()
        {
            author.Id = 1;
            Assert.AreEqual(1, author.Id);
        }

        [TestMethod]
        public void LastNameShouldBeValid()
        {
            author.LastName = "Costache";
            bool isIntString = author.LastName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void LastNameShouldBeInvalid()
        {
            author.LastName = "Costache123";
            bool isIntString = author.LastName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeValid()
        {
            author.FirstName = "Stelian";
            bool isIntString = author.FirstName.All(char.IsLetter);
            Assert.IsTrue(isIntString);
        }

        [TestMethod]
        public void FirstNameShouldBeInvalid()
        {
            author.FirstName = "1223Andrei";
            bool isIntString = author.FirstName.All(char.IsLetter);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void AuthorBooksShouldBeNull()
        {
            author.Books = null;

            Assert.IsNull(author.Books);
        }

        [TestMethod]
        public void AuthorBooksShouldHaveOneEntry()
        {
            var book = new Book()
            {
                Title = "Nu imi plac testele",
                LecturesOnlyBook = false,
                Authors = null,
                Domains = null,
                Editions = null
            };

            author.Books = new List<Book>();
            author.Books.Add(book);

            Assert.IsNotNull(author.Books);
        }
    }
}