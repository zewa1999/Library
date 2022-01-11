// <copyright file="BaseService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using FluentValidation;
    using Library.DataLayer.Interfaces;
    using Library.ServiceLayer.IServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

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
        protected U repository;

        /// <summary>
        /// The validator
        /// </summary>
        protected IValidator<T> validator;

        /// <summary>
        /// The properties repository
        /// </summary>
        protected L propertiesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{T, U, L}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="propRepo">The property repo.</param>
        protected BaseService(U repository, L propRepo)
        {
            this.repository = repository;
            this.propertiesRepository = propRepo;
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public virtual bool Insert(T entity)
        {
            var result = this.validator.Validate(entity);
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
                this.repository.Insert(entity);
            }

            return true;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public virtual bool Update(T entity)
        {
            var result = this.validator.Validate(entity);
            Utils.LogErrors(result);
            if (result.IsValid)
            {
                this.repository.Update(entity);
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
            return this.repository.Delete(entity);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public virtual bool DeleteById(object id)
        {
            return this.repository.DeleteById(id);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id"> The identifier. </param>
        public virtual T GetByID(object id)
        {
            return this.repository.GetByID(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return this.repository.Get(filter, orderBy, includeProperties);
        }
    }
}