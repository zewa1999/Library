// ***********************************************************************
// Assembly         : Library
// Author           : costa
// Created          : 01-06-2022
//
// Last Modified By : costa
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="BorrowerRepository.cs" company="Transilvania University of Brasov">
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
    /// Methods for the borrower controller.
    /// </summary>
    public class BorrowerRepository : BaseRepository<Borrower>, IBorrowerRepository
    {
    }
}