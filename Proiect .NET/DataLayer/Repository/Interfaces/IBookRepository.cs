// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
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
        public Domain GetParentDomain(Domain domain);
        public void GetDomains(Domain domain, List<Domain> domains);
        public IEnumerable<Book> GetUnavailableBooks(IEnumerable<Book> allBooksWithTheSameName);
        public IEnumerable<Book> GetBooksWithTheSameTitle(string title);
    }
}