// <copyright file="BorrowerRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Concretes namespace.
/// </summary>
namespace Library.DataLayer.Concretes
{
    using Library.DataLayer.Interfaces;
    using Library.DomainLayer.Person;

    /// <summary>
    /// Methods for the borrower controller.
    /// </summary>
    public class BorrowerRepository : BaseRepository<Borrower>, IBorrowerRepository
    {
    }
}