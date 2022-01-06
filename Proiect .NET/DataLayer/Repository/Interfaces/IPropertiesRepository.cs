// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Library.DomainLayer;

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    /// <summary>
    /// Interface IPropertiesRepository
    /// Implements the <see cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />
    public interface IPropertiesRepository : IRepository<Properties>
    {
        public Properties GetLastProperties();
    }
}