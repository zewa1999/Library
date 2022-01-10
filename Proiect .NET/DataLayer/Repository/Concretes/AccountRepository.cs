// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="AccountRepository.cs" company="Transilvania University of Brasov">
//     Costache Stelian-Andrei
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.DataMapper;
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer.Person;
    using Ninject.Activation;

    /// <summary>
    /// The Concretes namespace.
    /// <seealso cref="Library.DataLayer.Interfaces.IAccountRepository"/>
    /// </summary>
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}