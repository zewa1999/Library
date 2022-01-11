// <copyright file="BorrowTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.DomainLayer.Tests.PersonTests
{
    using Library.DomainLayer.Person;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class BorrowTests
    {
        private Borrow borrow;

        [TestInitialize]
        public void Initialize()
        {
            this.borrow = new Borrow();
        }

        [TestMethod]
        public void BorrowShouldHaveAValidBorrower()
        {
            var borrower = new Borrower();
            borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "vali@mail.com",
            };

            this.borrow = new()
            {
                Borrower = borrower,
                BorrowedBooks = null,
            };

            Assert.IsNotNull(this.borrow.Borrower);
        }

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

            this.borrow = new()
            {
                Borrower = null,
                BorrowedBooks = borrowedBooks,
            };

            Assert.IsNotNull(this.borrow.BorrowedBooks);
        }

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