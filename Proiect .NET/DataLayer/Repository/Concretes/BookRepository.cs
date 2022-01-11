// <copyright file="BookRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;

    /// <summary>
    /// Methods for the author controller.
    /// </summary>
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        /// <summary>
        /// Gets the domains list.
        /// </summary>
        /// <param name="book"> The book. </param>
        /// <returns> ceva. </returns>
        public List<Domain> GetDomainsList(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                domainsList.Add(domain);

                this.GetDomains(domain, domainsList);
            }

            return domainsList;
        }

        /// <summary>
        /// Gets the books with the same title.
        /// </summary>
        /// <param name="title"> The title. </param>
        /// <returns> ceva. </returns>
        public IEnumerable<Book> GetBooksWithTheSameTitle(string title)
        {
            try
            {
                return from book in this.Ctx.Books where book.Title == title select book;
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + "The query could not been made, will return empty list!");
            }

            return new List<Book>();
        }

        /// <summary>
        /// Gets the books with the same title.
        /// </summary>
        /// <param name="allBooksWithTheSameName"> The title. </param>
        /// <returns> IEnumerable of Book. </returns>
        public IEnumerable<Book> GetUnavailableBooks(IEnumerable<Book> allBooksWithTheSameName)
        {
            try
            {
                return from book in allBooksWithTheSameName where (bool)book.IsBorrowed || (bool)book.LecturesOnlyBook select book;
            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message + "The query could not been made, will return empty list!");
            }

            return new List<Book>();
        }

        /// <summary>
        /// Books the has correct domains.
        /// </summary>
        /// <param name="book"> The book. </param>
        /// <returns><c> true </c> if XXXX, <c>false</c> otherwise. </returns>
        public bool BookHasCorrectDomains(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                this.GetDomains(domain, domainsList);
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

        /// <summary>
        /// Gets the domains.
        /// </summary>
        /// <param name="domain"> The domain. </param>
        /// <param name="domains"> The domains. </param>
        public void GetDomains(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain.ParentDomain);
                return;
            }

            if (domains.Count == 0)
            {
                this.GetDomains(domain.ParentDomain, domains);
            }
            else
            {
                domains.Add(domain.ParentDomain);
                this.GetDomains(domain.ParentDomain, domains);
            }
        }

        /// <summary>
        /// Gets the parent domain.
        /// </summary>
        /// <param name="domain"> The domain. </param>
        /// /// <returns> Domain. </returns>
        public Domain GetParentDomain(Domain domain)
        {
            if (domain.ParentDomain == null)
            {
                return domain;
            }

            return this.GetParentDomain(domain.ParentDomain);
        }

        /// <summary>
        /// Checks if domain exists.
        /// </summary>
        /// <param name="domain"> The domain. </param>
        /// <param name="domains"> The domains. </param>
        /// <returns><c> true </c> if XXXX, <c>false</c> otherwise. </returns>
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

            return this.CheckIfDomainExists(domain.ParentDomain, domains);
        }
    }
}