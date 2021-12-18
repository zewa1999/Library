// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
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