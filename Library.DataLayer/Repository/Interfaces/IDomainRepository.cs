// ***********************************************************************
// Assembly         : Library.DataLayer
// Author           : costa
// Created          : 11-25-2021
//
// Last Modified By : costa
// Last Modified On : 12-17-2021
// ***********************************************************************
// <copyright file="IDomainRepository.cs" Company Name="Transilvania University of Brasov">
//    "Copyright (c) Costache Stelian-Andrei. All rights reserved." #
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface for the domain controller.
    /// </summary>
    public interface IDomainRepository : IRepository<Domain>
    {
    }
}