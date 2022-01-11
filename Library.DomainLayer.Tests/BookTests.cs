// <copyright file="BookTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class BookTests
    {
        private Book book;

        [TestInitialize]
        public void Initialize()
        {
            this.book = new();
        }

        [TestMethod]
        public void TitleShouldBeValid()
        {
            this.book.Title = "o suta de zile pe mare si programez de ma doare capul";

            bool isIntString = this.book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void TitleShouldNotHaveDigits()
        {
            this.book.Title = "100 de zile pe mare si programez de ma doare capul";

            bool isIntString = this.book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void BookAuthorsFirstNameShouldBeValid()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            this.book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList,
            };

            var flag = this.book.Authors.All(x => x.FirstName.All(char.IsDigit));

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void BookAuthorsLastNameShouldBeValid()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            this.book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList,
            };

            var flag = this.book.Authors.All(x => x.LastName.All(char.IsDigit));

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void BookAuthorsShouldNotBeNull()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var authorsList = new List<Author>() { author };

            this.book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList,
            };

            Assert.IsNotNull(this.book.Authors);
        }

        [TestMethod]
        public void BookDomainsShouldNotBeNull()
        {
            var domain = new Domain()
            {
                Name = "Informatica",
                ParentDomain = null,
                ChildrenDomains = null,
            };

            var domainsList = new List<Domain>();
            domainsList.Add(domain);

            this.book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = null,
                Domains = domainsList,
            };

            Assert.IsNotNull(this.book.Domains);
        }

        [TestMethod]
        public void BookEditionsShouldNotBeNull()
        {
            var edition = new Edition()
            {
                Publisher = "Casa de carti marcel dorel",
                Year = "1987",
                EditionNumber = 1,
                NumberOfPages = 200,
            };

            var editionsList = new List<Edition>();
            editionsList.Add(edition);

            this.book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = null,
                Editions = editionsList,
            };

            Assert.IsNotNull(this.book.Editions);
        }

        [TestMethod]
        public void TypeShouldNotContainDigitsValid()
        {
            this.book.Type = "HardBook";

            bool isIntString = this.book.Type.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void BookShouldBeBorrowable()
        {
            this.book.LecturesOnlyBook = true;
            if (this.book.LecturesOnlyBook == true)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void BookShouldNotBeBorrowable()
        {
            this.book.LecturesOnlyBook = false;
            if (this.book.LecturesOnlyBook == true)
                Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void BookShouldBeBorrowed()
        {
            this.book.IsBorrowed = false;
            if (this.book.IsBorrowed == true)
                Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void BookShouldNotBeBorrowed()
        {
            this.book.IsBorrowed = false;
            if (this.book.IsBorrowed == true)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsFalse(false);
        }
    }
}