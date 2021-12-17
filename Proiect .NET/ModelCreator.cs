// ***********************************************************************
// Assembly         : Library.UI
// Author           : costa
// Created          : 12-07-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="ModelCreator.cs" company="Library.UI">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation.Results;
using Library.DomainLayer;
using Library.DomainLayer.Person;
using Library.DomainLayer.Validators;
using System.Collections.Generic;

namespace Proiect_.NET
{
    /// <summary>
    /// Class ModelCreator.
    /// </summary>
    public class ModelCreator
    {
        /// <summary>
        /// The logger
        /// </summary>
        //private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCreator"/> class.
        /// </summary>
        public ModelCreator()
        {
            //_logger = LogManager.GetCurrentClassLogger();
        }

        public Account CreateAccountModel(string phone, string email)
        {
            var account = new Account()
            {
                PhoneNumber = phone,
                Email = email
            };

            AccountValidator validator = new();
            ValidationResult results = validator.Validate(account);
            CheckErrors(results);
            return account;
        }

        public Borrower CreateBorrowerModel(string firstName, string lastName, string address, Account account)
        {
            var borrower = new Borrower()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Account = account
            };

            BorrowerValidator validator = new();
            ValidationResult results = validator.Validate(borrower);
            CheckErrors(results);
            return borrower;
        }

        public Borrower CreateLibrarianModel(string firstName, string lastName, string address, Account account, bool isReader)
        {
            var librarian = new Librarian()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Account = account,
                IsReader = isReader
            };

            LibrarianValidator validator = new();
            ValidationResult results = validator.Validate(librarian);
            CheckErrors(results);
            return librarian;
        }

        public Author CreateAuthorModel(string firstName, string lastName, ICollection<Book> books)
        {
            var author = new Author()
            {
                FirstName = firstName,
                LastName = lastName,
                Books = books
            };

            AuthorValidator validator = new();
            ValidationResult results = validator.Validate(author);
            CheckErrors(results);

            return author;
        }

        public Book CreateBookModel(string title, bool isBorrowable, ICollection<Author> authors, ICollection<Domain> domains, ICollection<Edition> editions)
        {
            var book = new Book()
            {
                Title = title,
                IsBorrowable = isBorrowable,
                Authors = authors,
                Domains = domains,
                Editions = editions
            };

            BookValidator validator = new();
            ValidationResult results = validator.Validate(book);
            CheckErrors(results);

            return book;
        }

        public Borrow CreateBorrowModel(Borrower borrower, ICollection<Book> borrowedBooks)
        {
            var borrow = new Borrow()
            {
                Borrower = borrower,
                BorrowedBooks = borrowedBooks
            };

            BorrowValidator validator = new();
            ValidationResult results = validator.Validate(borrow);
            CheckErrors(results);

            return borrow;
        }

        public Domain CreateDomainModel(string name, Domain? parentDomain, ICollection<Domain> childrenDomains)
        {
            var domain = new Domain()
            {
                Name = name,
                ParentDomain = parentDomain,
                ChildrenDomains = childrenDomains
            };

            DomainValidator validator = new();
            ValidationResult results = validator.Validate(domain);
            CheckErrors(results);

            return domain;
        }

        public Edition CreateEditionModel(string publisher, string year, int editionNumber, int numberOfPages)
        {
            var edition = new Edition()
            {
                Publisher = publisher,
                Year = year,
                EditionNumber = editionNumber,
                NumberOfPages = numberOfPages
            };

            EditionValidator validator = new();
            ValidationResult results = validator.Validate(edition);
            CheckErrors(results);

            return edition;
        }

        private bool CheckErrors(ValidationResult results)
        {
            if (results.IsValid == false)
            {
                foreach (var error in results.Errors)
                {
                    // _logger.Error($"{error.ErrorMessage}");
                }
                return false;
            }
            return true;
        }
    }
}