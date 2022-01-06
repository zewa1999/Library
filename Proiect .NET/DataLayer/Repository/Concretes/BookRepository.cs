// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Methods for the author controller.
    /// </summary>
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {

        public List<Domain> GetDomainsList(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                domainsList.Add(domain);
                GetDomains(domain, domainsList);
            }
            return domainsList;
        }


        public IEnumerable<Book> GetBooksWithTheSameTitle(string title)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                return from book in ctx.Books where book.Title == title select book;
                }
                catch(Exception ex)
                {
                    logger.Error(ex.Message + "The query could not been made, will return empty list!");
                }
            }
            return new List<Book>();
        }

        public IEnumerable<Book> GetUnavailableBooks(IEnumerable<Book> allBooksWithTheSameName)
        {
            using (var ctx = new LibraryContext())
            {
                try
                {
                return from book in allBooksWithTheSameName where (bool)book.IsBorrowed || (bool)book.LecturesOnlyBook select book;
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message + "The query could not been made, will return empty list!");
                }
            }
            return new List<Book>();

        }

        public bool BookHasCorrectDomains(Book book)
        {

            var domainsList = new List<Domain>();
            foreach (var domain in book.Domains)
            {
                GetDomains(domain, domainsList);
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

        private bool CheckIfDomainExists(Domain domain, List<Domain> domains)
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

        public void GetDomains(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain.ParentDomain);
                return;
            }

            if(domains.Count == 0)
            {
            GetDomains(domain.ParentDomain, domains);
            }
            else
            {
            domains.Add(domain.ParentDomain);
            GetDomains(domain.ParentDomain, domains);
            }
        }

        public Domain GetParentDomain(Domain domain)
        {
            if (domain.ParentDomain == null)
            {
                return domain;
            }

            return GetParentDomain(domain.ParentDomain);
        }
    }
}