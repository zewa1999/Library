// <copyright file="PropertiesService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

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
        private readonly IValidator validator;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IPropertiesRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesService" /> class.
        /// </summary>
        public PropertiesService()
        {
            this.repository = Injector.Create<IPropertiesRepository>();
            this.validator = new PropertiesValidator();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(Properties entity)
        {
            return this.repository.Delete(entity);
        }

        /// <summary>
        /// Deletes the by identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteById(object entity)
        {
            return this.repository.DeleteById(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        public IEnumerable<Properties> GetAll(Expression<Func<Properties, bool>> filter = null,
            Func<IQueryable<Properties>, IOrderedQueryable<Properties>> orderBy = null,
            string includeProperties = "")
        {
            return this.repository.Get(filter, book => book.OrderBy(x => x.Id), includeProperties);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Properties GetByID(object id)
        {
            return this.repository.GetByID(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public bool Insert(Properties entity)
        {
            var context = new ValidationContext<Properties>(entity);
            ValidationResult result = this.validator.Validate(context);
            if (result.IsValid)
            {
                this.repository.Insert(entity);
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
            ValidationResult result = this.validator.Validate(context);
            if (result.IsValid)
            {
                this.repository.Insert(entity);
                return true;
            }

            return false;
        }
    }
}