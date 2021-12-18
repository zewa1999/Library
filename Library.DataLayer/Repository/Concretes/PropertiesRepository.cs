// ***********************************************************************
// Assembly         : Library.DataLayer
// Author           : costa
// Created          : 12-18-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="PropertiesRepository.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************
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