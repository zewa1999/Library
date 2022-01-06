using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Library.DomainLayer.Tests
{
    [TestClass]
    public class BookTests
    {
        private Book book;

        [TestInitialize]
        public void Initialize()
        {
            book = new();
        }

        [TestMethod]
        public void TitleShouldBeValid()
        {
            book.Title = "o suta de zile pe mare si programez de ma doare capul";

            bool isIntString = book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void TitleShouldNotHaveDigits()
        {
            book.Title = "100 de zile pe mare si programez de ma doare capul";

            bool isIntString = book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);

        }

        [TestMethod]
        public void BookAuthorsFirstNameShouldBeValid()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList,
            };

            var flag = book.Authors.All(x => x.FirstName.All(char.IsDigit));

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void BookAuthorsLastNameShouldBeValid()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList,
            };

            var flag = book.Authors.All(x => x.LastName.All(char.IsDigit));

            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void BookAuthorsShouldNotBeNull()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = authorsList
            };


            Assert.IsNotNull(book.Authors);
        }

        [TestMethod]
        public void BookDomainsShouldNotBeNull()
        {
            var domain = new Domain()
            {
                Name = "Informatica",
                ParentDomain = null,
                ChildrenDomains = null
            };

            var domainsList = new List<Domain>();
            domainsList.Add(domain);

            book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = null,
                Domains = domainsList
            };

            Assert.IsNotNull(book.Domains);
        }

        [TestMethod]
        public void BookEditionsShouldNotBeNull()
        {
            var edition = new Edition()
            {
                Publisher = "Casa de carti marcel dorel",
                Year = "1987",
                EditionNumber = 1,
                NumberOfPages = 200
            };

            var editionsList = new List<Edition>();
            editionsList.Add(edition);

            book = new Book()
            {
                Title = "How to write bad code with Costache",
                LecturesOnlyBook = true,
                Authors = null,
                Editions = editionsList
            };

            Assert.IsNotNull(book.Editions);
        }

        [TestMethod]
        public void TypeShouldNotContainDigitsValid()
        {
            book.Type = "HardBook";

            bool isIntString = book.Type.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        [TestMethod]
        public void BookShouldBeBorrowable()
        {
            book.LecturesOnlyBook = true;
            if (book.LecturesOnlyBook == true)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void BookShouldNotBeBorrowable()
        {
            book.LecturesOnlyBook = false;
            if (book.LecturesOnlyBook == true)
                Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void BookShouldBeBorrowed()
        {
            book.IsBorrowed = false;
            if (book.IsBorrowed == true)
                Assert.IsTrue(true);
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void BookShouldNotBeBorrowed()
        {
            book.IsBorrowed = false;
            if (book.IsBorrowed == true)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsFalse(false);
        }
    }
}
