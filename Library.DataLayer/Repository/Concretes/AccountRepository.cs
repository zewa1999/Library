// ***********************************************************************
// Assembly         : Library.DataLayer
// Author           : costa
// Created          : 12-18-2021
//
// Last Modified By : costa
// Last Modified On : 12-18-2021
// ***********************************************************************
// <copyright file="AccountRepository.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    }
}