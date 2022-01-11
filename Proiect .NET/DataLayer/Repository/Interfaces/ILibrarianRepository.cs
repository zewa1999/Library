// <copyright file="ILibrarianRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface for the librarian controller.
    /// </summary>
    public interface ILibrarianRepository : IRepository<Librarian>
    {
    }
}