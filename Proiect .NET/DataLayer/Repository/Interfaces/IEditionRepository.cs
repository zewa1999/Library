// <copyright file="IEditionRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface for the edition controller.
    /// </summary>
    public interface IEditionRepository : IRepository<Edition>
    {
    }
}