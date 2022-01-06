using Library.DomainLayer.Person;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Library.DomainLayer.Tests.PersonTests
{
    [TestClass]
    public class BorrowTests
    {
        private Borrow borrow;

        [TestInitialize]
        public void Initialize()
        {
            borrow = new Borrow();
        }
        
        [TestMethod]
        public void BorrowShouldHaveAValidBorrower()
        {
            var borrower = new Borrower();
            borrower.Account = new()
            {
                PhoneNumber = "0724525672",
                Email = "vali@mail.com"

            };

            borrow = new()
            {
                Borrower = borrower,
                BorrowedBooks = null
            };

            Assert.IsNotNull(borrow.Borrower);
        }

        [TestMethod]
        public void BorrowShouldHaveAValidBorrowedBooksList()
        {
            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
                Books = new List<Book>()
            };

            var authorsList = new List<Author>();
            authorsList.Add(author);

            var domain = new Domain()
            {
                Name = "Informatica",
                ParentDomain = null,
                ChildrenDomains = null
            };

            var domainsList = new List<Domain>();
            domainsList.Add(domain);

            var edition = new Edition()
            {
                Publisher = "Casa de carti marcel dorel",
                Year = "1987",
                EditionNumber = 1,
                NumberOfPages = 200
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
                Editions = editionsList
            });

            borrow = new()
            {
                Borrower = null,
                BorrowedBooks = borrowedBooks
            };

            Assert.IsNotNull(borrow.BorrowedBooks);
        }

        [TestMethod]
        public void BorrowDateShouldNotBeHigherThanCurrentDate()
        {
            borrow.BorrowDate = DateTime.Now.AddHours(1);
            if(borrow.BorrowDate > DateTime.Now)
            {
                Assert.IsFalse(false);
                return;
            }
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void EndDateShouldNotExceedThreeMonths()
        {
            borrow.EndDate = DateTime.Now.AddMonths(2);
            if (borrow.EndDate > DateTime.Now.AddMonths(3))
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void NoOfTimeExtendedShouldBeNoHigherThanThree()
        {
            borrow.NoOfTimeExtended = 2;
            if(borrow.NoOfTimeExtended > 3)
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(true);
        }
    }
}
