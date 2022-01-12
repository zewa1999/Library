// <copyright file="TestUtils.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Tests
{
    using System;
    using System.Collections.Generic;
    using Library.DomainLayer;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Class TestUtils.
    /// </summary>
    public static class TestUtils
    {
        /// <summary>
        /// Gets the borrow model.
        /// </summary>
        /// <returns> ceva. </returns>
        public static Borrow GetBorrowModel()
        {
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
                NumberOfPages = 250,
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
            };

            var editions = new List<Edition>();
            editions.Add(edition);
            var domains = new List<Domain>();
            domains.Add(domain);
            var authors = new List<Author>();
            authors.Add(author);

            var book = new Book()
            {
                Title = "Head first design patters",
                LecturesOnlyBook = false,
                IsBorrowed = false,
                Type = "Hard  cover",
                Authors = authors,
                Domains = domains,
                Editions = editions,
            };

            return new Borrow()
            {
                BorrowDate = DateTime.Now.AddMonths(-1),
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                BorrowedBooks = new List<Book>() { book },
            };
        }

        /// <summary>
        /// Gets the borrow model with identifier.
        /// </summary>
        /// <returns> ceva. </returns>
        public static Borrow GetBorrowModelWithId()
        {
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
                NumberOfPages = 1,
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

            return new Borrow()
            {
                Id = 1,
                BorrowDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                NoOfTimeExtended = 1,
                Borrower = borrower,
                BorrowedBooks = new List<Book>() { book },
            };
        }

        /// <summary>
        /// Gets the book model.
        /// </summary>
        /// <returns> ceva. </returns>
        public static Book GetBookModel()
        {
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
                NumberOfPages = 250,
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
            };

            return new Book()
            {
                Title = "Head first design patters",
                LecturesOnlyBook = false,
                IsBorrowed = false,
                Type = "Hard  cover",
                Authors = new List<Author>() { author },
                Domains = new List<Domain>() { domain },
                Editions = new List<Edition>() { edition },
            };
        }

        /// <summary>
        /// Gets the list of books.
        /// </summary>
        /// <returns> list of books. </returns>
        public static List<Book> GetListOfBooks()
        {
            var list = new List<Book>();

            for (int i = 0; i < 30; i++)
            {
                list.Add(GetBookModel());
            }

            return list;
        }

        /// <summary>
        /// Gets the book model with identifier.
        /// </summary>
        /// <returns> ceva. </returns>
        public static Book GetBookModelWithId()
        {
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
                NumberOfPages = 1,
            };

            var borrower = new Borrower()
            {
                LastName = "Gogu",
                FirstName = "Mortu",
                Address = "Bucuresti, strada Mihai Viteazu, nr 7, bloc C3, ap 26",
                Account = account,
            };

            return new Book()
            {
                Id = 1,
                Title = "Head first design patters",
                LecturesOnlyBook = false,
                IsBorrowed = false,
                Type = "Hard  cover",
                Authors = new List<Author>() { author },
                Domains = new List<Domain>() { domain },
                Editions = new List<Edition>() { edition },
            };
        }
    }
}