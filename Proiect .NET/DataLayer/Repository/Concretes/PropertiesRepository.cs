// <copyright file="PropertiesRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;
    using System;
    using System.Linq;

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
                var lastPropertiesId = this.ctx.Properties.Max(x => x.Id);
                return this.ctx.Properties.FirstOrDefault(x => x.Id == lastPropertiesId);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + "The query could not been made!");
            }
            return new Properties();
        }
    }
}