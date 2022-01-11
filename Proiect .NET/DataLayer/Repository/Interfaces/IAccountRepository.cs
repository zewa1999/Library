// <copyright file="IAccountRepository.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

/// <summary>
/// The Interfaces namespace.
/// </summary>
namespace Library.DataLayer.Interfaces
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface IAccountRepository
    /// Implements the <see cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Person.Account}" />
    /// </summary>
    /// <seealso cref="Library.DataLayer.Interfaces.IRepository{Library.DomainLayer.Person.Account}" />
    public interface IAccountRepository : IRepository<Account>
    {
    }
}