// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="PropertiesRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.DataMapper;
using Library.DataLayer.Interfaces;
using Library.DomainLayer;
using System;
using System.Linq;

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
        /// <summary>
        /// Gets the last properties.
        /// </summary>
        public Properties GetLastProperties()
        {
            try
            {
                var lastPropertiesId = ctx.Properties.Max(x => x.Id);
                return ctx.Properties.FirstOrDefault(x => x.Id == lastPropertiesId);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + "The query could not been made!");
            }
            return new Properties();
        }
    }
}