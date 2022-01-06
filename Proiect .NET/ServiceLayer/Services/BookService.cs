// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BookService.cs" company="Library.ServiceLayer">
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
using System.Collections.Generic;
using System.Linq;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class BookService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBookService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBookService" />
    public class BookService : BaseService<Book, IBookRepository, IPropertiesRepository>, IBookService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="bookRepository">The book repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BookService()
            : base(Injector.Create<IBookRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new BookValidator();
        }

        public override ValidationResult Insert(Book entity)
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
        private bool CheckFlags(Book book)
        {
            var properties = _propertiesRepository.GetLastProperties();

            if (book.Domains.Count > properties.Domenii)
                return false;
            if (BookHasCorrectDomains(book) == false)
                return false;

            AddAncestorDomains(book);
            return true;

        }

        #region Flags
        public bool CheckIfDomainExists(Domain domain, List<Domain> domains)
        {
            var noOfBadDomains = (from d in domains where d.Id == domain.Id select d).Count();

            if (domain.ParentDomain == null)
            {
                domains.Add(domain);
                return false;
            }

            if (noOfBadDomains >= 1)
            {
                return false;
            }

            return CheckIfDomainExists(domain.ParentDomain, domains);
        }
        //Se va verifica faptul ca o carte nu poate sa se specifice explicit ca fiind din domenii aflate in relatia stramos-descendent.
        public bool BookHasCorrectDomains(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                GetDomainsWithoutTheFirst(domain, domainsList);
                foreach (var parentDomain in domainsList)
                {
                    if (domain.Id == parentDomain.Id)
                    {
                        return false;
                    }
                }
                domainsList.Clear();
            }
            return true;
        }

        private void GetDomainsWithoutTheFirst(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain.ParentDomain);
                return;
            }

            if (domains.Count == 0)
            {
                GetDomainsWithoutTheFirst(domain.ParentDomain, domains);
            }
            else
            {
                domains.Add(domain.ParentDomain);
                GetDomainsWithoutTheFirst(domain.ParentDomain, domains);
            }
        }

        //Daca o carte face parte dintr-un subdomeniu, automat va fi regasita si ca fiind parte din
        //domeniile stramos, fara ca acest lucru sa fie declarat explicit in
        // asta e la insert
        public void AddAncestorDomains(Book book)
        {
            GetDomainsList(book);
            book.Domains = GetDomainsList(book);
        }

        public List<Domain> GetDomainsList(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                domainsList.Add(domain);
                GetDomainsWithTheFirst(domain, domainsList);
            }
            return domainsList;
        }

        private void GetDomainsWithTheFirst(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain.ParentDomain);
                return;
            }

            domains.Add(domain.ParentDomain);
            GetDomainsWithTheFirst(domain.ParentDomain, domains);
        }
    }
    #endregion Flags
}