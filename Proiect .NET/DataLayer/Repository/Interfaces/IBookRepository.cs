// <copyright file="IBookRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using System.Collections.Generic;
    using Library.DomainLayer;

    /// <summary>
    /// Interface for the book controller.
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Gets the parent domain.
        /// </summary>
        /// <param name="domain"> The domain. </param>
        /// <returns> ceva. </returns>
        public Domain GetParentDomain(Domain domain);

        /// <summary>
        /// Gets the domains.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="domains">The domains.</param>
        public void GetDomains(Domain domain, List<Domain> domains);

        /// <summary>
        /// Gets the unavailable books.
        /// </summary>
        /// <param name="allBooksWithTheSameName"> Name of all books with the same. </param>
        /// <returns> ceva. </returns>
        public IEnumerable<Book> GetUnavailableBooks(IEnumerable<Book> allBooksWithTheSameName);

        /// <summary>
        /// Gets the books with the same title.
        /// </summary>
        /// <param name="title"> The title. </param>
        /// <returns> ceva. </returns>
        public IEnumerable<Book> GetBooksWithTheSameTitle(string title);
    }
}