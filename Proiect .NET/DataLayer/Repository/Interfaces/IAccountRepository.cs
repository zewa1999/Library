// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
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
    }
}