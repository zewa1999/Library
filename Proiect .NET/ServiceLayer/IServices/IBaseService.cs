// <copyright file="IBaseService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for the repository.
    /// </summary>
    /// <typeparam name="T"> Ceva. </typeparam>
    public interface IBaseService<T>
        where T : class
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> T. </returns>
        bool Insert(T entity);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> T. </returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> T. </returns>
        bool Delete(T entity);

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> T. </returns>
        bool DeleteById(object entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        /// <returns> T. </returns>
        T GetByID(object id);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter"> filter. </param>
        /// <param name="orderBy"> orderBy. </param>
        /// <param name="includeProperties"> includeProperties. </param>
        /// <returns> IEnumerable<typeparamref name="T"/>. </returns>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}