// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="AccountRepository.cs" company="Library">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Library.DataLayer.DataMapper;
using Library.DataLayer.Interfaces;
using Library.DomainLayer.Person;

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    /// <summary>
    /// Class AccountRepository.
    /// Implements the <see cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Person.Account}" />
    /// Implements the <see cref="Library.DataLayer.Interfaces.IAccountRepository" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.BaseRepository{Library.DomainLayer.Person.Account}" />
    /// <seealso cref="Library.DataLayer.Interfaces.IAccountRepository" />
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public bool Insert2(Account entity)
        {
            using (var ctx = new LibraryContext())
            {
                ctx.Accounts.Add(entity);
                ctx.SaveChanges();
            }
            return true;
        }
    }
}