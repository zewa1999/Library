// <copyright file="AccountRepository.cs" company="Transilvania University of Brasov">
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
    /// The Concretes namespace.
    /// <seealso cref="Library.DataLayer.Interfaces.IAccountRepository"/>
    /// </summary>
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
    }
}