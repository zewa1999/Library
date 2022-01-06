// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="PropertiesService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using FluentValidation.Results;
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;
using System;
using System.Collections.Generic;

namespace Library.ServiceLayer.Services
{
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
            _repository = Injector.Create<IPropertiesRepository>();
            _validator = new PropertiesValidator();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(Properties entity)
        {
            _repository.Delete(entity);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;Properties&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Properties> GetAll()
        {
            return _repository.Get();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Properties.</returns>
        public Properties GetByID(object id)
        {
            return _repository.GetByID(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        public ValidationResult Insert(Properties entity)
        {
            var context = new ValidationContext<Properties>(entity);
            ValidationResult result = _validator.Validate(context);
            if (result.IsValid)
            {
                _repository.Insert(entity);
            }

            return result;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValidationResult Update(Properties entity)
        {
            var context = new ValidationContext<Properties>(entity);
            ValidationResult result = _validator.Validate(context);
            if (result.IsValid)
            {
                _repository.Insert(entity);
            }

            return result;
        }
    }
}