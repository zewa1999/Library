// ***********************************************************************
// Assembly         : Library.ServiceLayer
// Author           : costa
// Created          : 12-17-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="AccountService.cs" company="Library.ServiceLayer">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using FluentValidation.Results;
using Library.DataLayer.Interfaces;
using Library.DataLayer.Validators;
using Library.DomainLayer.Person;
using Library.ServiceLayer.IServices;

namespace Library.ServiceLayer.Services
{
    /// <summary>
    /// Class AccountService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Account, Library.DataLayer.Interfaces.IAccountRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IAccountService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Person.Account, Library.DataLayer.Interfaces.IAccountRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IAccountService" />
    public class AccountService : BaseService<Account, IAccountRepository>, IAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountRepository">The account repository.</param>
        /// <param name="propertiesRepository">The properties repository.</param>
        public AccountService(IAccountRepository accountRepository, IPropertiesRepository propertiesRepository)
            : base(accountRepository, propertiesRepository)
        {
            _validator = new AccountValidator(propertiesRepository);
        }
    }
}