// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="PropertiesService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.ServiceLayer.Services
{
    using FluentValidation;
    using FluentValidation.Results;
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Class PropertiesService.
    /// Implements the <see cref="Library.ServiceLayer.IServices.IPropertiesService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IPropertiesService" />
    public class PropertiesService : IPropertiesService
    {
        /// <summary>
        /// The validator
        /// </summary>
        private readonly IValidator _validator;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IPropertiesRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesService" /> class.
        /// </summary>
        public PropertiesService()
        {
            this._repository = Injector.Create<IPropertiesRepository>();
            this._validator = new PropertiesValidator();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Properties entity)
        {
            return this._repository.Delete(entity);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteById(object entity)
        {
            return this._repository.DeleteById(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public IEnumerable<Properties> GetAll(Expression<Func<Properties, bool>> filter = null,
            Func<IQueryable<Properties>, IOrderedQueryable<Properties>> orderBy = null,
            string includeProperties = "")
        {
            return this._repository.Get(filter, book => book.OrderBy(x => x.Id), includeProperties);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Properties GetByID(object id)
        {
            return this._repository.GetByID(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public bool Insert(Properties entity)
        {
            var context = new ValidationContext<Properties>(entity);
            ValidationResult result = this._validator.Validate(context);
            if (result.IsValid)
            {
                this._repository.Insert(entity);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public bool Update(Properties entity)
        {
            var context = new ValidationContext<Properties>(entity);
            ValidationResult result = this._validator.Validate(context);
            if (result.IsValid)
            {
                this._repository.Insert(entity);
                return true;
            }

            return false;
        }
    }
}