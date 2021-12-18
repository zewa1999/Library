// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Library.DataLayer.Interfaces;
using Library.DomainLayer;

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    /// <summary>
    /// Class PropertiesRepository.
    /// Implements the <see cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Properties}" />
    /// Implements the <see cref="Library.DataLayer.Interfaces.IPropertiesRepository" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Properties}" />
    /// <seealso cref="Library.DataLayer.Interfaces.IPropertiesRepository" />
    public class PropertiesRepository : BaseRepository<Properties>, IPropertiesRepository
    {
    }
}