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
            this.service.DeleteAll();
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

            // Insert 30 books
            var bookService = Injector.Create<BookService>();
            var listOfBooks = TestUtils.GetListOfBooks();
            foreach (var bookToBeInserted in listOfBooks)
            {
                // Assert if books are added succesfully
                Assert.IsTrue(bookService.Insert(bookToBeInserted));
            }

            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };
            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
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

            // Add books that will be borrowed
            var listOfBooksToBeBorrowed = new List<Book>();
            var allBooks = bookService.GetAll(null, book => book.OrderBy(x => x.Id), string.Empty).ToList();

            var borrow = new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(-2),
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                Librarian = librarian,
                BorrowedBooks = new List<Book>(),
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
            borrow.BorrowedBooks.Add(allBooks.FirstOrDefault());
            borrow.BorrowedBooks.Add(allBooks.LastOrDefault());
            borrow.Borrower.Account.Email = "validEmail@gmail.com";

            Assert.IsTrue(this.service.Update(dbBorrow));

            // Delete
            Assert.IsTrue(this.service.DeleteById(dbBorrow.Id));
        }

        /// <summary>
        /// Defines the test method BadInsertTest.
        /// </summary>
        [TestMethod]
        public void BadInsertTest()
        {
            var borrow = new Borrow();

            Assert.IsFalse(this.service.Insert(borrow));
        }

        /// <summary>
        /// Defines the test method CheckIfBooksAreBorrowableShouldReturnFalse.
        /// </summary>
        [TestMethod]
        public void CheckIfBooksAreBorrowableShouldReturnFalse()
        {
            var borrow = new Borrow()
            {
                BorrowedBooks = new List<Book>() { TestUtils.GetBookModel() },
            };

            Assert.IsFalse(this.service.CheckIfBooksAreBorrowable(borrow));
        }

        /// <summary>
        /// Defines the test method CheckIfBooksAreBorrowableShouldReturnFalse.
        /// </summary>
        [TestMethod]
        public void CheckIfBooksAreBorrowableShouldReturnFalseWhenBorrowHasMoreThanOneBook()
        {
            var borrow = new Borrow()
            {
                BorrowedBooks = new List<Book>() { TestUtils.GetBookModel(), TestUtils.GetBookModel() },
            };

            Assert.IsFalse(this.service.CheckIfBooksAreBorrowable(borrow));
        }

        /// <summary>
        /// Defines the test method CheckLIMShouldReturnFalse.
        /// </summary>
        [TestMethod]
        public void CheckLIMShouldReturnFalse()
        {
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

            var book = TestUtils.GetBookModel();
            var borrow = new Borrow()
            {
                BorrowedBooks = new List<Book>() { TestUtils.GetBookModel(), TestUtils.GetBookModel() },
                NoOfTimeExtended = propertiesService.GetAll(null, prop => prop.OrderBy(x => x.Id), string.Empty).LastOrDefault().LIM + 1,
            };

            Assert.IsFalse(this.service.CheckLIM(borrow));
        }

        /// <summary>
        /// Defines the test method GetParentDomainShouldReturnCorrectParentDomain.
        /// </summary>
        [TestMethod]
        public void GetParentDomainShouldReturnCorrectParentDomain()
        {
            var parent = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
            };

            var children = new Domain()
            {
                Name = "Chimie",
                ParentDomain = parent,
            };

            Assert.AreEqual(parent, this.service.GetParentDomain(children));
        }

        /// <summary>
        /// Defines the test method GetNoOfDistinctCategoriesShouldReturns1.
        /// </summary>
        [TestMethod]
        public void GetNoOfDistinctCategoriesShouldReturns1()
        {
            var d1 = new Domain()
            {
                Name = "Stiinta",
                ParentDomain = null,
            };

            var d2 = new Domain()
            {
                Name = "Literatura",
                ParentDomain = null,
            };

            var d3 = new Domain()
            {
                Name = "Medicina",
                ParentDomain = null,
            };

            var listOfDomains = new List<Domain>() { d1, d2, d3 };

            Assert.AreEqual(3, this.service.GetNoOfDistinctCategories(listOfDomains));
        }

        /// <summary>
        /// Defines the test method CheckMaxBorrowBooksTodayShouldReturnTrueWhenBorrowsTableIsEmpty.
        /// </summary>
        [TestMethod]
        public void CheckMaxBorrowBooksTodayShouldReturnTrueWhenBorrowsTableIsEmpty()
        {
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

            Assert.IsTrue(this.service.CheckMaxBorrowBooksToday());
        }

        /// <summary>
        /// Defines the test method CheckCanBorrowMaxNMCInPERShouldReturnFaLse.
        /// </summary>
        [TestMethod]
        public void CheckCanBorrowMaxNMCInPERShouldReturnFaLse()
        {
            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
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

            // Create and add borrows

            // Insert 30 books
            var bookService = Injector.Create<BookService>();
            var listOfBooks = TestUtils.GetListOfBooks();
            foreach (var bookToBeInserted in listOfBooks)
            {
                // Assert if books are added succesfully
                Assert.IsTrue(bookService.Insert(bookToBeInserted));
            }

            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };
            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
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

            // Add books that will be borrowed
            var listOfBooksToBeBorrowed = new List<Book>();
            var allBooks = bookService.GetAll(null, book => book.OrderBy(x => x.Id), string.Empty).ToList();

            var borrow = new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(-2),
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                Librarian = librarian,
                BorrowedBooks = new List<Book>(),
            };

            this.service.Insert(borrow);

            // Update
            borrow.BorrowedBooks.Add(allBooks.FirstOrDefault());
            borrow.BorrowedBooks.Add(allBooks.LastOrDefault());
            borrow.Borrower.Account.Email = "validEmail@gmail.com";

            Assert.IsTrue(this.service.Update(borrow));

            // Last
            Assert.IsFalse(this.service.CheckCanBorrowMaxNMCInPER(borrow));
        }

        /// <summary>
        /// Defines the test method CheckBorrowedBooksForMaxCBooksShouldReturnTrue.
        /// </summary>
        [TestMethod]
        public void CheckBorrowedBooksForMaxCBooksShouldReturnTrue()
        {
            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
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

            var book1 = TestUtils.GetBookModel();
            var book2 = TestUtils.GetBookModel();
            book2.Domains.First().Name = "Literatura";
            var book3 = TestUtils.GetBookModel();
            book3.Domains.First().Name = "Literatura";

            var borrow = new Borrow()
            {
                BorrowedBooks = new List<Book>() { book1, book2, book3 },
            };

            Assert.IsTrue(this.service.CheckBorrowedBooksForMaxCBooks(borrow));
        }

        /// <summary>
        /// Defines the test method CheckBorrowInDELTATimeShouldReturnTrue.
        /// </summary>
        [TestMethod]
        public void CheckBorrowInDELTATimeShouldReturnFalse()
        {
            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
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

            // Insert 30 books
            var bookService = Injector.Create<BookService>();
            var listOfBooks = TestUtils.GetListOfBooks();
            foreach (var bookToBeInserted in listOfBooks)
            {
                // Assert if books are added succesfully
                Assert.IsTrue(bookService.Insert(bookToBeInserted));
            }

            var author = new Author()
            {
                FirstName = "Marcel",
                LastName = "Dorel",
            };

            var account = new Account()
            {
                PhoneNumber = "0734525427",
                Email = "gogumortu@gmail.com",
            };
            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
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

            // Add books that will be borrowed
            var listOfBooksToBeBorrowed = new List<Book>();
            var allBooks = bookService.GetAll(null, book => book.OrderBy(x => x.Id), string.Empty).ToList();

            var borrow = new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(-2),
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                Librarian = librarian,
                BorrowedBooks = new List<Book>(),
            };

            Assert.IsTrue(this.service.Insert(borrow));

            // Update
            borrow.BorrowedBooks.Add(allBooks.LastOrDefault());
            borrow.Borrower.Account.Email = "validEmail@gmail.com";

            Assert.IsTrue(this.service.Update(borrow));

            Assert.IsFalse(this.service.CheckBorrowInDELTATime(borrow));
        }

        /// <summary>
        /// Defines the test method TestCheckBorrowedBooksForMaxCBooks.
        /// </summary>
        [TestMethod]
        public void TestCheckBorrowedBooksForMaxCBooks()
        {
            var borrow = new Borrow()
            {
                Borrower = new Librarian()
                {
                    IsReader = true,
                },
                BorrowedBooks = new List<Book>()
                {
                    new Book(),
                    new Book(),
                    new Book(),
                    new Book(),
                    new Book(),
                },
            };

            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
                L = 2,
                C = 1,
                D = 1,
                LIM = 2,
                DELTA = 3,
                NCZ = 4,
                PERSIMP = 3,
                PER = 3,
            };

            // Insert Properties
            Assert.IsTrue(propertiesService.Insert(properties));

            Assert.IsFalse(this.service.CheckBorrowedBooksForMaxCBooks(borrow));

            borrow.BorrowedBooks.Remove(new Book());
            borrow.BorrowedBooks = new List<Book>();

            Assert.IsTrue(this.service.CheckBorrowedBooksForMaxCBooks(borrow));
        }

        /// <summary>
        /// Defines the test method TestCheckIfBooksAreBorrowable.
        /// </summary>
        [TestMethod]
        public void TestCheckIfBooksAreBorrowable()
        {
            var borrow = new Borrow()
            {
                Borrower = new Librarian()
                {
                    IsReader = true,
                },
                BorrowedBooks = new List<Book>()
                {
                    new Book()
                    {
                        LecturesOnlyBook = true,
                    },
                },
            };

            Assert.IsFalse(this.service.CheckIfBooksAreBorrowable(borrow));
        }

        /// <summary>
        /// Defines the test method TestCheckBorrowInDELTATime.
        /// </summary>
        [TestMethod]
        public void TestCheckBorrowInDELTATime()
        {
            var borrow = new Borrow()
            {
                Borrower = new Librarian()
                {
                    IsReader = true,
                },
                BorrowedBooks = new List<Book>()
                {
                    new Book(),
                },
            };

            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
                L = 2,
                C = 1,
                D = 1,
                LIM = 2,
                DELTA = 3,
                NCZ = 4,
                PERSIMP = 3,
                PER = 3,
            };

            // Insert Properties
            Assert.IsTrue(propertiesService.Insert(properties));

            Assert.IsTrue(this.service.CheckBorrowInDELTATime(borrow));
        }


        /// <summary>
        /// Defines the test method TestCheckCanBorrowMaxNMCInPER.
        /// </summary>
        [TestMethod]
        public void TestCheckCanBorrowMaxNMCInPER()
        {
            var borrow = new Borrow()
            {
                Borrower = new Librarian()
                {
                    IsReader = true,
                },
                BorrowedBooks = new List<Book>()
                {
                    new Book(),
                },
            };

            var propertiesService = Injector.Create<PropertiesService>();
            var properties = new Properties()
            {
                DOMENII = 2,
                NMC = 2,
                L = 2,
                C = 1,
                D = 1,
                LIM = 2,
                DELTA = 3,
                NCZ = 4,
                PERSIMP = 3,
                PER = 3,
            };

            // Insert Properties
            Assert.IsTrue(propertiesService.Insert(properties));

            Assert.IsTrue(this.service.CheckCanBorrowMaxNMCInPER(borrow));
        }

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            // Clean table
            Assert.IsTrue(this.service.DeleteAll());

            // Clean Librarian table
            var librarianService = Injector.Create<LibrarianService>();
            Assert.IsTrue(librarianService.DeleteAll());

            // Clean Borrower table
            var borrowerService = Injector.Create<BorrowerService>();
            Assert.IsTrue(borrowerService.DeleteAll());

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
            var propertiesService = Injector.Create<PropertiesService>();
            Assert.IsTrue(propertiesService.DeleteAll());

            // Clean Book table
            var bookService = Injector.Create<BookService>();
            Assert.IsTrue(bookService.DeleteAll());
        }
    }
}
