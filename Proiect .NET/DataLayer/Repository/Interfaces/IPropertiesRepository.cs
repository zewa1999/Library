// <copyright file="IPropertiesRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface IPropertiesRepository
    /// Implements the <see cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />.
    /// </summary>
    /// <seealso cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />
    public interface IPropertiesRepository : IRepository<Properties>
    {
        /// <summary>
        /// Gets the last properties.
        /// </summary>
        /// <returns></returns>
        public Properties GetLastProperties();
    }
}