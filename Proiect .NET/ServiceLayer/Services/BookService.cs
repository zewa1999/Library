// <copyright file="BookService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation;
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class BookService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBookService" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Book, Library.DataLayer.Interfaces.IBookRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBookService" />
    public class BookService : BaseService<Book, IBookRepository, IPropertiesRepository>, IBookService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService" /> class.
        /// </summary>
        public BookService()
            : base(Injector.Create<IBookRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.Validator = new BookValidator();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> ceva. </returns>
        public override bool Insert(Book entity)
        {
            if (entity.Authors.Count == 0)
            {
                this.Validator = new BookWithoutAuthorsValidator();
            }

            var result = this.Validator.Validate(entity);
            if (result.IsValid && this.CheckFlags(entity))
            {
                this.Repository.Insert(entity);
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            this.Validator = new BookValidator();
            return true;
        }

        /// <summary>
        /// Checks if domain exists.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="domains">The domains.</param>
        /// <returns> ceva. </returns>
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

            return this.CheckIfDomainExists(domain.ParentDomain, domains);
        }

        /// <summary>
        ///  Se va verifica faptul ca o carte nu poate sa se specifice explicit ca fiind din domenii aflate in relatia stramos-descendent.
        /// Books the has correct domains.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns> ceva. </returns>
        public bool BookHasCorrectDomains(Book book)
        {
            var domainsList = new List<Domain>();

            foreach (var domain in book.Domains)
            {
                this.GetDomainsWithoutTheFirst(domain, domainsList);
                foreach (var parentDomain in domainsList)
                {
                    if (parentDomain != null && domain.Id == parentDomain.Id)
                    {
                        return false;
                    }
                }

                domainsList.Clear();
            }

            return true;
        }

        /// <summary>
        /// Daca o carte face parte dintr-un subdomeniu, automat va fi regasita si ca fiind parte din
        /// domeniile stramos, fara ca acest lucru sa fie declarat explicit in
        /// asta e la insert
        /// Adds the ancestor domains.
        /// </summary>
        /// <param name="book">The book.</param>
        public void AddAncestorDomains(Book book)
        {
            book.Domains = this.GetDomainsList(book);
        }

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
                this.GetDomainsWithTheFirst(domain, domainsList);
            }

            return domainsList;
        }

        /// <summary>
        /// Gets the domains without the first.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="domains">The domains.</param>
        private void GetDomainsWithoutTheFirst(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain.ParentDomain);
                return;
            }

            if (domains.Count == 0)
            {
                this.GetDomainsWithoutTheFirst(domain.ParentDomain, domains);
            }
            else
            {
                domains.Add(domain.ParentDomain);
                this.GetDomainsWithoutTheFirst(domain.ParentDomain, domains);
            }
        }

        /// <summary>
        /// Gets the domains with the first.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="domains">The domains.</param>
        private void GetDomainsWithTheFirst(Domain domain, List<Domain> domains)
        {
            if (domain.ParentDomain == null)
            {
                domains.Add(domain);
                return;
            }

            domains.Add(domain.ParentDomain);
            this.GetDomainsWithTheFirst(domain.ParentDomain, domains);
        }

        /// <summary>
        /// Checks the flags.
        /// </summary>
        /// <param name="book">The book.</param>
        private bool CheckFlags(Book book)
        {
            var properties = this.PropertiesRepository.GetLastProperties();

            if (book.Domains.Count > properties.DOMENII)
            {
                return false;
            }

            if (this.BookHasCorrectDomains(book) == false)
            {
                return false;
            }

            this.AddAncestorDomains(book);
            return true;
        }
    }
}