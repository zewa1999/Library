﻿// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="IPropertiesRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface IPropertiesRepository
    /// Implements the <see cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Properties}" />
    public interface IPropertiesRepository : IRepository<Properties>
    {
        /// <summary>
        /// Gets the last properties.
        /// </summary>
        public Properties GetLastProperties();
    }
}