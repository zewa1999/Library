// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="IAccountRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DomainLayer.Person;

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    /// <summary>
    /// Interface IAccountRepository
    /// Implements the <see cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Person.Account}" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Person.Account}" />
    public interface IAccountRepository : IRepository<Account>
    {
        public bool Insert2(Account entity);
    }
}