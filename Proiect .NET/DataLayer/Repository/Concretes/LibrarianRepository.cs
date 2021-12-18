// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Methods for the librarian controller.
    /// </summary>
    public class LibrarianRepository : BaseRepository<Librarian>, ILibrarianRepository
    {
    }
}