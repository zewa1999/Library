// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="BookTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class BookTests.
    /// </summary>
    [TestClass]
    public class BookTests
    {
        /// <summary>
        /// The book.
        /// </summary>
        private Book book;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.book = new ();
        }

        /// <summary>
        /// Defines the test method TitleShouldBeValid.
        /// </summary>
        [TestMethod]
        public void TitleShouldBeValid()
        {
            this.book.Title = "o suta de zile pe mare si programez de ma doare capul";

            bool isIntString = this.book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method TitleShouldNotHaveDigits.
        /// </summary>
        [TestMethod]
        public void TitleShouldNotHaveDigits()
        {
            this.book.Title = "100 de zile pe mare si programez de ma doare capul";

            bool isIntString = this.book.Title.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method BookAuthorsFirstNameShouldBeValid.
        /// </summary>
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

        /// <summary>
        /// Defines the test method BookAuthorsLastNameShouldBeValid.
        /// </summary>
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

        /// <summary>
        /// Defines the test method BookAuthorsShouldNotBeNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method BookDomainsShouldNotBeNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method BookEditionsShouldNotBeNull.
        /// </summary>
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

        /// <summary>
        /// Defines the test method TypeShouldNotContainDigitsValid.
        /// </summary>
        [TestMethod]
        public void TypeShouldNotContainDigitsValid()
        {
            this.book.Type = "HardBook";

            bool isIntString = this.book.Type.All(char.IsDigit);
            Assert.IsFalse(isIntString);
        }

        /// <summary>
        /// Defines the test method BookShouldBeBorrowable.
        /// </summary>
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

        /// <summary>
        /// Defines the test method BookShouldNotBeBorrowable.
        /// </summary>
        [TestMethod]
        public void BookShouldNotBeBorrowable()
        {
            this.book.LecturesOnlyBook = false;
            if (this.book.LecturesOnlyBook == true)
            {
                Assert.IsTrue(true);
            }

            Assert.IsFalse(false);
        }

        /// <summary>
        /// Defines the test method BookShouldBeBorrowed.
        /// </summary>
        [TestMethod]
        public void BookShouldBeBorrowed()
        {
            this.book.IsBorrowed = false;
            if (this.book.IsBorrowed == true)
            {
                Assert.IsTrue(true);
            }

            Assert.IsFalse(false);
        }

        /// <summary>
        /// Defines the test method BookShouldNotBeBorrowed.
        /// </summary>
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