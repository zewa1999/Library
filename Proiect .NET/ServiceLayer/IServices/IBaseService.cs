﻿// ***********************************************************************
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
    using System.Collections.Generic;

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
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        bool Insert(T entity);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Delete(T entity);

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool DeleteById(object entity);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T GetByID(object id);

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetAll();
    }
}