// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;

    /// <summary>
    /// Methods for the author controller.
    /// </summary>
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
    }
}