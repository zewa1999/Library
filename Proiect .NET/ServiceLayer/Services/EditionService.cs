// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="EditionService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class EditionService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Edition, Library.DataLayer.Interfaces.IEditionRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IEditionService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Edition, Library.DataLayer.Interfaces.IEditionRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IEditionService" />
    public class EditionService : BaseService<Edition, IEditionRepository, IPropertiesRepository>, IEditionService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditionService" /> class.
        /// </summary>
        public EditionService()
            : base(Injector.Create<IEditionRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new EditionValidator();
        }
    }
}