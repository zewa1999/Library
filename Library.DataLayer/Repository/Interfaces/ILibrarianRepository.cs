// ***********************************************************************
// Assembly         : Library.DataLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-08-2021
// ***********************************************************************
// <copyright file="ILibrarianRepository.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface for the librarian controller.
    /// </summary>
    public interface ILibrarianRepository : IRepository<Librarian>
    {
    }
}