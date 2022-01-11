// <copyright file="LibrarianRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Concretes namespace.
/// </summary>

namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer.Person;

    public class LibrarianRepository : BaseRepository<Librarian>, ILibrarianRepository
    {
    }
}