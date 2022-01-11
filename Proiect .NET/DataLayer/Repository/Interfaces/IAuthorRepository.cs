// <copyright file="IAuthorRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface for the author controller.
    /// </summary>
    public interface IAuthorRepository : IRepository<Author>
    {
    }
}