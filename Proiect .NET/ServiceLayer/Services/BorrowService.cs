// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="BorrowService.cs" company="Library.ServiceLayer">
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
    /// Class BorrowService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBorrowService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Borrow, Library.DataLayer.Interfaces.IBorrowRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IBorrowService" />
    public class BorrowService : BaseService<Borrow, IBorrowRepository, IPropertiesRepository>, IBorrowService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowService"/> class.
        /// </summary>
        /// <param name="borrowRepository">The borrow repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public BorrowService()
             : base(Injector.Create<IBorrowRepository>(), Injector.Create<IPropertiesRepository>())
        {
            _validator = new BorrowValidator(_propertiesRepository);
        }
    }
}