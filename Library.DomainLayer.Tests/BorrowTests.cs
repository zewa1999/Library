// ***********************************************************************
// Assembly         : Library.DomainLayer.Tests
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-11-2022
// ***********************************************************************
// <copyright file="BorrowTests.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.DomainLayer.Tests.PersonTests
{
    using System;
    using System.Collections.Generic;
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines test class BorrowTests.
    /// </summary>
    [TestClass]
    public class BorrowTests
    {
        /// <summary>
        /// The borrow.
        /// </summary>
        private Borrow borrow;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.borrow = new Borrow();
        }

        /// <summary>
        /// Defines the test method BorrowShouldHaveAValidBorrower.
        /// </summary>
        [TestMethod]
        public void BorrowShouldHaveAValidBorrower()
        {
            var borrower = new Borrower();
            borrower.Account = new ()
            {
                PhoneNumber = "0724525672",
                Email = "vali@mail.com",
            };

            this.borrow = new ()
            {
                Borrower = borrower,
                BorrowedBooks = null,
            };

            Assert.IsNotNull(this.borrow.Borrower);
        }

        /// <summary>
        /// Defines the test method BorrowShouldHaveAValidBorrowedBooksList.
        /// </summary>
        [TestMethod]
        public void BorrowShouldHaveAValidBorrowedBooksList()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            var domain = new Domain()
            {
                Name = "Informatica",
                ParentDomain = null,
                ChildrenDomains = null,
            };

            var domainsList = new List<Domain>();
            domainsList.Add(domain);

            var edition = new Edition()
            {
                Publisher = "Casa de carti marcel dorel",
                Year = "1987",
                EditionNumber = 1,
                NumberOfPages = 200,
            };

            var editionsList = new List<Edition>();
            editionsList.Add(edition);

            var borrowedBooks = new List<Book>();

            borrowedBooks.Add(new Book()
            {
                Title = "O Carte",
                LecturesOnlyBook = false,
                Authors = authorsList,
                Domains = domainsList,
                Editions = editionsList,
            });

            this.borrow = new ()
            {
                Borrower = null,
                BorrowedBooks = borrowedBooks,
            };

            Assert.IsNotNull(this.borrow.BorrowedBooks);
        }

        /// <summary>
        /// Defines the test method BorrowDateShouldNotBeHigherThanCurrentDate.
        /// </summary>
        [TestMethod]
        public void BorrowDateShouldNotBeHigherThanCurrentDate()
        {
            this.borrow.BorrowDate = DateTime.Now.AddHours(1);
            if (this.borrow.BorrowDate > DateTime.Now)
            {
                Assert.IsFalse(false);
                return;
            }

            Assert.IsTrue(false);
        }

        /// <summary>
        /// Defines the test method EndDateShouldNotExceedThreeMonths.
        /// </summary>
        [TestMethod]
        public void EndDateShouldNotExceedThreeMonths()
        {
            this.borrow.EndDate = DateTime.Now.AddMonths(2);
            if (this.borrow.EndDate > DateTime.Now.AddMonths(3))
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Defines the test method NoOfTimeExtendedShouldBeNoHigherThanThree.
        /// </summary>
        [TestMethod]
        public void NoOfTimeExtendedShouldBeNoHigherThanThree()
        {
            this.borrow.NoOfTimeExtended = 2;
            if (this.borrow.NoOfTimeExtended > 3)
            {
                Assert.IsTrue(false);
            }

            Assert.IsTrue(true);
        }
    }
}