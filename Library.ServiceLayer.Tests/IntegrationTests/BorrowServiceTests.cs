// <copyright file="BorrowServiceTests.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;
    using Library.ServiceLayer.IServices;
    using Library.ServiceLayer.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Defines test class BorrowServiceTests.
    /// </summary>
    [TestClass]
    public class BorrowServiceTests
    {
        private BorrowService service;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            Injector.Initialize();
            this.service = Injector.Create<BorrowService>();
        }

        /// <summary>
        /// Defines the test method EndToEndBorrow.
        /// </summary>
        [TestMethod]
        public void EndToEndBorrow()
        {
            // Add properties
            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 3,
                L = 2,
                C = 3,
                D = 2,
                LIM = 2,
                DELTA = 3,
                NCZ = 4,
                PERSIMP = 3,
                PER = 3,
            };

            // Insert Properties
            Assert.IsTrue(propertiesService.Insert(properties));

            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var domain = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
                ChildrenDomains = new List<Domain>(),
            };

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };

            var edition = new Edition()
            {
                Publisher = "Cartea studentilor saraci",
                Year = "1999",
                EditionNumber = int.MaxValue,
                NumberOfPages = 200,
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
            };
            var book = new Book()
            {
                Title = "Head first design patters",
                LecturesOnlyBook = false,
                IsBorrowed = false,
                Type = "Hard  cover",
                Authors = new List<Author>() { author },
                Domains = new List<Domain>() { domain },
                Editions = new List<Edition>() { edition },
            };

            var librarianAccount = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };

            var librarian = new Librarian()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                IsReader = true,
                Account = librarianAccount,
            };

            var borrow = new Borrow()
            {
                BorrowDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                Librarian = librarian,
                BorrowedBooks = new List<Book>() { book },
            };

            // Insert
            Assert.IsTrue(this.service.Insert(borrow));

            // GetById intr-un fel, din cauza ca adauga prea multe in baza de date..
            var dbBorrow = this.service.GetAll(null, null, string.Empty).LastOrDefault();
            Assert.IsNotNull(dbBorrow);
            Assert.IsNotNull(this.service.GetByID(dbBorrow.Id));

            // GetAll
            var allBorrows = this.service.GetAll(null, null, string.Empty);
            Assert.IsNotNull(allBorrows);

            // Update
            borrow.NoOfTimeExtended = 3;
            borrow.Borrower.Account.Email = "validEmail@gmail.com";
            Assert.IsTrue(this.service.Update(dbBorrow));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbBorrow.Id));

            // Clean table
            Assert.IsTrue(this.service.DeleteAll());

            // Clean Librarian table
            var librarianService = Injector.Create<LibrarianService>();
            Assert.IsTrue(librarianService.DeleteAll());

            // Clean Borrower table
            var borrowerService = Injector.Create<BorrowerService>();
            Assert.IsTrue(borrowerService.DeleteAll());

            // Clean Book table
            var bookService = Injector.Create<BookService>();
            Assert.IsTrue(bookService.DeleteAll());

            // Clean Author table
            var authorService = Injector.Create<AuthorService>();
            Assert.IsTrue(authorService.DeleteAll());

            // Clean Domain table
            var domainService = Injector.Create<DomainService>();
            Assert.IsTrue(domainService.DeleteAll());

            // Clean Edition table
            var editionService = Injector.Create<EditionService>();
            Assert.IsTrue(editionService.DeleteAll());

            // Clean Account table
            var accountService = Injector.Create<AccountService>();
            Assert.IsTrue(accountService.DeleteAll());

            // Clean Properties table
            Assert.IsTrue(propertiesService.DeleteAll());
        }
    }
}
