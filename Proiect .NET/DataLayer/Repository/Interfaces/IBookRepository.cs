// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="IBookRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the book controller.
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Gets the parent domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>Domain.</returns>
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
        /// <param name="allBooksWithTheSameName">Name of all books with the same.</param>
        /// <returns>IEnumerable&lt;Book&gt;.</returns>
        public IEnumerable<Book> GetUnavailableBooks(IEnumerable<Book> allBooksWithTheSameName);

        /// <summary>
        /// Gets the books with the same title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns>IEnumerable&lt;Book&gt;.</returns>
        public IEnumerable<Book> GetBooksWithTheSameTitle(string title);
    }
}