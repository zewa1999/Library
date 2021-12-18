// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
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