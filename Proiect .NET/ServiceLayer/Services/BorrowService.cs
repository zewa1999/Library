// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BorrowService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.ServiceLayer.Services
{
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class BorrowService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBorrowService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBorrowService" />
    public class BorrowService : BaseService<Borrow, IBorrowRepository, IPropertiesRepository>, IBorrowService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowService" /> class.
        /// </summary>
        /// <param name="borrowRepository">The borrow repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>

        private readonly IBookRepository bookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowService" /> class.
        /// </summary>
        public BorrowService()
             : base(Injector.Create<IBorrowRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.bookRepository = Injector.Create<IBookRepository>();
            this._validator = new BorrowValidator();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public override bool Insert(Borrow entity)
        {
            var result = this._validator.Validate(entity);
            if (result.IsValid && this.CheckFlags(entity))
            {
                this._repository.Insert(entity);
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the flags.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckFlags(Borrow entity)
        {
            var properties = this._propertiesRepository.GetLastProperties();
            var numberOfBorrowedBooks = this.GetNumberOfBorrowedBooks(entity.Id);
            DateTime maxPeriodOfTimeForBorrowing = this.GetMaximumPeriodOfTimeForBorrowing(entity, properties);

            if (!this.CheckIfBooksAreBorrowable(entity))
                return false;
            // Pot imprumuta un numar maxim de carti NMC intr-o perioada PER

            if (numberOfBorrowedBooks >= properties.NrMaximCartiImprumutate || maxPeriodOfTimeForBorrowing > DateTime.Now)
                return false;
            // Pot imprumuta cel mult NCZ carti intr-o zi.
            if (entity.BorrowedBooks.Count > properties.NumarCartiImprumutateZilnic)
                return false;
            //La un imprumut pot prelua cel mult C carti; daca numarul cartilor imprumutate
            //la o cerere de imprumut e cel putin 3,
            //atunci acestea trebui sa faca parte din cel putin 2 categorii distincte
            if (entity.BorrowedBooks.Count >= properties.NumarMaximCarti && entity.BorrowedBooks.Count >= 3 && this.CheckDistinctCategories(entity))
                return false;
            if (this.CheckNoOfBooksOfTheSameDomain())
                return false;
            if (this.CheckSameBookBorrowingInADeltaTime(entity))
                return false;

            return true;
        }

        #region Check Flags

        /// <summary>
        /// Gets the number of borrowed books.
        /// </summary>
        /// <param name="borrowerId"> The borrower identifier. </param>
        public int GetNumberOfBorrowedBooks(int borrowerId)
        {
            var numberOfBooksBorrowed = 0;
            var listOfBorrows = this._repository.Get(null, book => book.OrderBy(x => x.Id), "");
            foreach (var borrow in listOfBorrows)
            {
                if (borrow.Borrower.Id == borrowerId)
                {
                    numberOfBooksBorrowed += borrow.BorrowedBooks.Count;
                }
            }

            return numberOfBooksBorrowed;
        }

        /// <summary>
        /// Gets the maximum period of time for borrowing.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <param name="properties"> The properties. </param>
        private DateTime GetMaximumPeriodOfTimeForBorrowing(Borrow entity, Properties properties)
        {
            var firstBorrowDate = this._repository.GetFirstBorrowDate(entity.Id);
            var maxPeriodOfTimeForBorrowing = firstBorrowDate.AddMonths((int)properties.Perioada);
            return maxPeriodOfTimeForBorrowing;
        }

        /// <summary>
        /// Checks the lim.
        /// </summary>
        /// <param name="borrowedBook">The borrowed book.</param>
        private bool CheckLIM(Book borrowedBook)
        {
            var properties = this._propertiesRepository.GetLastProperties();
            var listOfBorrows = this._repository.Get(null, book => book.OrderBy(x => x.Id), "");

            foreach (var borrow in listOfBorrows)
            {
                foreach (var book in borrow.BorrowedBooks)
                {
                    if (book.Id == borrowedBook.Id && borrow.NoOfTimeExtended >= properties.LimitaMaximaImprumut)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the same book borrowing in a delta time.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckSameBookBorrowingInADeltaTime(Borrow entity)
        {
            var listOfBorrows = this._repository.Get(null, book => book.OrderBy(x => x.Id), "");
            var properties = this._propertiesRepository.GetLastProperties();
            var deltaTime = DateTime.Now.AddMonths((int)-properties.Delta);

            foreach (var borrow in listOfBorrows)
            {
                foreach (var book in borrow.BorrowedBooks)
                {
                    foreach (var borrowedBook in entity.BorrowedBooks)
                    {
                        if (book.Id == borrowedBook.Id && borrow.BorrowDate >= deltaTime && deltaTime <= borrow.BorrowDate)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the no of books of the same domain.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckNoOfBooksOfTheSameDomain()
        {
            int noOfBooksWithTheSameDomain = 0;
            var properties = this._propertiesRepository.GetLastProperties();
            var listOfBorrows = this.GetBooksBetweenPastMonthsAndPresent((int)properties.L);
            var domainDictionary = new Dictionary<string, int>();
            foreach (var borrow in listOfBorrows)
            {
                foreach (var book in borrow.BorrowedBooks)
                {
                    foreach (var domain in book.Domains)
                    {
                        if (domainDictionary.ContainsKey(domain.Name))
                        {
                            domainDictionary[domain.Name]++;
                        }
                        else
                        {
                            domainDictionary.Add(domain.Name, 1);
                        }
                    }
                }
            }

            foreach (var item in domainDictionary)
            {
                if (item.Value >= properties.NrMaximCartiImprumutateAcelasiDomeniu)
                {
                    noOfBooksWithTheSameDomain++;
                }
            }

            if (noOfBooksWithTheSameDomain > properties.NrMaximCartiImprumutateAcelasiDomeniu)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if books are borrowable.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckIfBooksAreBorrowable(Borrow entity)
        {
            foreach (var book in entity.BorrowedBooks)
            {
                if (book.LecturesOnlyBook == true || this.CanBorrowBook(book.Title) || this.CheckLIM(book))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether this instance [can borrow book] the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns><c>true</c> if this instance [can borrow book] the specified title; otherwise, <c>false</c>.</returns>
        private bool CanBorrowBook(string title)
        {
            var allBooksWithTheSameName = this.bookRepository.GetBooksWithTheSameTitle(title);
            var unavailableBooks = this.bookRepository.GetUnavailableBooks(allBooksWithTheSameName);

            if (allBooksWithTheSameName.Count() * 0.1f < allBooksWithTheSameName.Count() - unavailableBooks.Count())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the distinct categories.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckDistinctCategories(Borrow entity)
        {
            var domainsList = new List<Domain>();
            foreach (var book in entity.BorrowedBooks)
            {
                var parentDomainsList = new List<Domain>();
                foreach (var domain in book.Domains)
                {
                    var parentDomain = this.bookRepository.GetParentDomain(domain);
                    parentDomainsList.Add(parentDomain);
                }
                domainsList.AddRange(parentDomainsList);
            }

            this.RemoveDomainsDuplicates(domainsList);
            if (domainsList.Count < 2)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the books between past months and present.
        /// </summary>
        /// <param name="months"> The months. </param>
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months)
        {
            return this._repository.GetBooksBetweenPastMonthsAndPresent(months);
        }

        /// <summary>
        /// Removes the domains duplicates.
        /// </summary>
        /// <param name="domainsList">The domains list.</param>
        private void RemoveDomainsDuplicates(List<Domain> domainsList)
        {
            var distinctDomainList = domainsList.GroupBy(i => i.Id)
                                                .Select(g => g.First()).ToList();
        }

        #endregion Check Flags
    }
}