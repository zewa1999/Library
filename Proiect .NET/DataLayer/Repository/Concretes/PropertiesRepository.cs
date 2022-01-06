// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
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
        public Properties GetLastProperties()
        {
            using (var ctx = new LibraryContext())
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
            }
            return new Properties();
        }
    }
}