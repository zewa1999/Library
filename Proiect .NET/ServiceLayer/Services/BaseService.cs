// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="BaseService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using FluentValidation.Results;
using Library.DataLayer.Interfaces;
using Library.ServiceLayer.IServices;
using System;
using System.Collections.Generic;

namespace Library.ServiceLayer.Services
{
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
            _repository = repository;
            _propertiesRepository = propRepo;
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        public virtual ValidationResult Insert(T entity)
        {
            Console.WriteLine("BaseService insert");
            var result = _validator.Validate(entity);
            var isValid = false;
            if (result.IsValid)
            {
                isValid = true;
            }
            else
            {
                Utils.LogErrors(result);
            }

            if (isValid == true)
            {
                Console.WriteLine("Repo insert");

                _repository.Insert(entity);
                Console.WriteLine("Repo after insert");
            }
            Console.WriteLine("Out insert");

            return result;
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>ValidationResult.</returns>
        public virtual ValidationResult Update(T entity)
        {
            var result = _validator.Validate(entity);
            Utils.LogErrors(result);
            if (result.IsValid)
            {
                _repository.Update(entity);
            }
            else
            {
                Utils.LogErrors(result);
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual bool Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public virtual bool DeleteById(object id)
        {
            return _repository.DeleteById(id);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public virtual T GetByID(object id)
        {
            return _repository.GetByID(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.Get();
        }
    }
}