// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BorrowService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation.Results;
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Services
{
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
        /// Initializes a new instance of the <see cref="BorrowService"/> class.
        /// </summary>
        /// <param name="borrowRepository">The borrow repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>

        private readonly IBookRepository bookRepository;
        public BorrowService()
             : base(Injector.Create<IBorrowRepository>(), Injector.Create<IPropertiesRepository>())
        {
            bookRepository = Injector.Create<IBookRepository>();
            _validator = new BorrowValidator();
        }

        public override ValidationResult Insert(Borrow entity)
        {
            var result = _validator.Validate(entity);
            Utils.LogErrors(result);
            if (result.IsValid && CheckFlags(entity))
            {
                _repository.Insert(entity);
            }
            else
            {
                Utils.LogErrors(result);
            }

            return result;
        }

        private bool CheckFlags(Borrow entity)
        {
            var properties = _propertiesRepository.GetLastProperties();
            var numberOfBorrowedBooks = GetNumberOfBorrowedBooks(entity.Id);
            DateTime maxPeriodOfTimeForBorrowing = GetMaximumPeriodOfTimeForBorrowing(entity, properties);

            if (!CheckIfBooksAreBorrowable(entity))
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
            if (entity.BorrowedBooks.Count >= properties.NumarMaximCarti && entity.BorrowedBooks.Count >= 3 && CheckDistinctCategories(entity))
                return false;
            if (CheckNoOfBooksOfTheSameDomain())
                return false;
            if (CheckSameBookBorrowingInADeltaTime(entity))
                return false;

            return true;
        }

        #region Check Flags

        public int GetNumberOfBorrowedBooks(int borrowerId)
        {
            var numberOfBooksBorrowed = 0;
            var listOfBorrows = _repository.Get();
            foreach (var borrow in listOfBorrows)
            {
                if (borrow.Borrower.Id == borrowerId)
                {
                    numberOfBooksBorrowed += borrow.BorrowedBooks.Count;
                }
            }

            return numberOfBooksBorrowed;
        }

        private DateTime GetMaximumPeriodOfTimeForBorrowing(Borrow entity, Properties properties)
        {
            var firstBorrowDate = _repository.GetFirstBorrowDate(entity.Id);
            var maxPeriodOfTimeForBorrowing = firstBorrowDate.AddMonths((int)properties.Perioada);
            return maxPeriodOfTimeForBorrowing;
        }

        private bool CheckLIM(Book borrowedBook)
        {
            var properties = _propertiesRepository.GetLastProperties();
            var listOfBorrows = _repository.Get();

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

        private bool CheckSameBookBorrowingInADeltaTime(Borrow entity)
        {
            var listOfBorrows = _repository.Get();
            var properties = _propertiesRepository.GetLastProperties();
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

        private bool CheckNoOfBooksOfTheSameDomain()
        {
            int noOfBooksWithTheSameDomain = 0;
            var properties = _propertiesRepository.GetLastProperties();
            var listOfBorrows = GetBooksBetweenPastMonthsAndPresent((int)properties.L);
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

        private bool CheckIfBooksAreBorrowable(Borrow entity)
        {

            foreach (var book in entity.BorrowedBooks)
            {
                if (book.LecturesOnlyBook == true || CanBorrowBook(book.Title) || CheckLIM(book))
                    return false;
            }

            return true;
        }

        private bool CanBorrowBook(string title)
        {
            var allBooksWithTheSameName = bookRepository.GetBooksWithTheSameTitle(title);
            var unavailableBooks = bookRepository.GetUnavailableBooks(allBooksWithTheSameName);

            if (allBooksWithTheSameName.Count() * 0.1f < allBooksWithTheSameName.Count() - unavailableBooks.Count())
            {
                return false;
            }
            return true;
        }

        private bool CheckDistinctCategories(Borrow entity)
        {
            var domainsList = new List<Domain>();
            foreach (var book in entity.BorrowedBooks)
            {

                var parentDomainsList = new List<Domain>();
                foreach (var domain in book.Domains)
                {
                    var parentDomain = bookRepository.GetParentDomain(domain);
                    parentDomainsList.Add(parentDomain);
                }
                domainsList.AddRange(parentDomainsList);
            }

            RemoveDomainsDuplicates(domainsList);
            if (domainsList.Count < 2)
            {
                return false;
            }

            return true;
        }
        public IEnumerable<Borrow> GetBooksBetweenPastMonthsAndPresent(int months)
        {
            return _repository.GetBooksBetweenPastMonthsAndPresent(months);
        }

        private void RemoveDomainsDuplicates(List<Domain> domainsList)
        {
            var distinctDomainList = domainsList.GroupBy(i => i.Id)
                                                .Select(g => g.First()).ToList();
        }



        #endregion Check Flags

    }
}