// <company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface for the borrower controller.
    /// </summary>
    public interface IBorrowerRepository : IRepository<Borrower>
    {
    }
}