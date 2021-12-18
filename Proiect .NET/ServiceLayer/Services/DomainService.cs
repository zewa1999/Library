// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="DomainService.cs" company="Library.ServiceLayer">
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
    /// Class DomainService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IDomainService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Domain, Library.DataLayer.Interfaces.IDomainRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IDomainService" />
    public class DomainService : BaseService<Domain, IDomainRepository, IPropertiesRepository>, IDomainService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainService"/> class.
        /// </summary>
        /// <param name="domainRepository">The domain repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public DomainService()
             : base(Injector.Create<IDomainRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new DomainValidator(_propertiesRepository);
        }
    }
}