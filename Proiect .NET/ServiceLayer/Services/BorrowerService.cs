// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BorrowerService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;
using Proiect_.NET.Injection;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class BorrowerService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Borrower, Library.DataLayer.Interfaces.IBorrowerRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBorrowerService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Borrower, Library.DataLayer.Interfaces.IBorrowerRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBorrowerService" />
    public class BorrowerService : BaseService<Borrower, IBorrowerRepository, IPropertiesRepository>, IBorrowerService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowerService"/> class.
        /// </summary>
        /// <param name="borrowerRepository">The borrower repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BorrowerService()
            : base(Injector.Create<IBorrowerRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new BorrowerValidator();
        }
    }
}