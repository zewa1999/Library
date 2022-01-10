﻿// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="DomainService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation;
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Proiect_.NET.DataLayer.Validators;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class DomainService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IDomainService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IDomainService" />
    public class DomainService : BaseService<Domain, IDomainRepository, IPropertiesRepository>, IDomainService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainService" /> class.
        /// </summary>
        public DomainService()
             : base(Injector.Create<IDomainRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new DomainValidator();
        }

        public override bool Insert(Domain entity)
        {
            if (entity.ParentDomain == null)
            {
                _validator = new BaseDomainValidator();
            }

            var result = _validator.Validate(entity);
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
                _repository.Insert(entity);
            }

            _validator = new DomainValidator();
            return true;
        }
    }
}