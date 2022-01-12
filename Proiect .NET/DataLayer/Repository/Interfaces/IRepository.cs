// <copyright file="IRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for the repository.
    /// </summary>
    /// <typeparam name="T"> ceva. </typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns><c> ceva. </returns>.
        bool Insert(T entity);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item"> The item. </param>
        /// <returns><c> ceva. </returns>.
        bool Update(T item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns><c> ceva. </returns>.
        bool DeleteById(object id);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c> ceva. </returns>.
        bool Delete(T entity);

        /// <summary>
        /// Deletes all entities from table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns><c> ceva. </returns>.
        bool DeleteAllEntitiesFromTable();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> ceva. </returns>.
        T GetByID(object id);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter"> The filter. </param>
        /// <param name="orderBy"> The order by. </param>
        /// <param name="includeProperties"> The include properties. </param>
        /// <returns><c> ceva. </returns>.
        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}