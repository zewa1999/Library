// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="BaseService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Library.ServiceLayer.Services
{
    using FluentValidation;
    using Library.DataLayer.Interfaces;
    using Library.ServiceLayer.IServices;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;

    /// <summary>
    /// Class BaseService.
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="L"></typeparam>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{T}" />
    public abstract class BaseService<T, U, L> : IBaseService<T>
        where T : class
        where U : IRepository<T>
        where L : IPropertiesRepository
    {
        /// <summary>
        /// The repository
        /// </summary>
        protected U _repository;

        /// <summary>
        /// The validator
        /// </summary>
        protected IValidator<T> _validator;

        /// <summary>
        /// The properties repository
        /// </summary>
        protected L _propertiesRepository;

        /// <summary>
        /// Ctor for base service
        /// </summary>
        /// <param name="repository">The actual repository that will fit into this class</param>
        /// <param name="propRepo">The property repo.</param>
        protected BaseService(U repository, L propRepo)
        {
            this._repository = repository;
            this._propertiesRepository = propRepo;
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public virtual bool Insert(T entity)
        {
            var result = this._validator.Validate(entity);
            var isValid = false;
            if (result.IsValid)
            {
                isValid = true;
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            if (isValid == true)
            {
                this._repository.Insert(entity);
            }

            return true;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public virtual bool Update(T entity)
        {
            var result = this._validator.Validate(entity);
            Utils.LogErrors(result);
            if (result.IsValid)
            {
                this._repository.Update(entity);
            }
            else
            {
                Utils.LogErrors(result);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Delete(T entity)
        {
            return this._repository.Delete(entity);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public virtual bool DeleteById(object id)
        {
            return this._repository.DeleteById(id);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public virtual T GetByID(object id)
        {
            return this._repository.GetByID(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return this._repository.Get(filter, orderBy, includeProperties);
        }
    }
}