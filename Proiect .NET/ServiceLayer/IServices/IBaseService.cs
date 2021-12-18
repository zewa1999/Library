﻿// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="IBaseService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Library.ServiceLayer.IServices
{
    using FluentValidation.Results;
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
        ValidationResult Insert(T entity);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        ValidationResult Update(T entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

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