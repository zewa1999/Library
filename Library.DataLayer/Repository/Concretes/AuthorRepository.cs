// ***********************************************************************
// Assembly         : Library.DataLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="AuthorRepository.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer;

    /// <summary>
    /// Methods for the author controller.
    /// </summary>
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
    }
}