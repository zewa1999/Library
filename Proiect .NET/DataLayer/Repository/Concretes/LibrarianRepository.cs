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

    /// <summary>
    /// Class LibrarianRepository.
    /// Implements the <see cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Person.Librarian}" />.
    /// Implements the <see cref="Library.DataLayer.Interfaces.ILibrarianRepository" />.
    /// </summary>
    /// <seealso cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Person.Librarian}" />.
    /// <seealso cref="Library.DataLayer.Interfaces.ILibrarianRepository" />.
    public class LibrarianRepository : BaseRepository<Librarian>, ILibrarianRepository
    {
    }
}