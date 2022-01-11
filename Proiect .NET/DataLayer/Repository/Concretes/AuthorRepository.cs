// <copyright file="AuthorRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
    }
}