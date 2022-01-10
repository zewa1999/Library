// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="IBaseService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Library.ServiceLayer.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;

    /// <summary>
    /// Interface for the repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T>
        where T : class
    {
        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        bool Insert(T entity);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        bool Update(T entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        bool Delete(T entity);

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        bool DeleteById(object entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        T GetByID(object id);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
    }
}