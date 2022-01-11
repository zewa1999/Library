// <copyright file="IAccountService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface IAccountService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Account}"/>.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Account}" />
    public interface IAccountService : IBaseService<Account>
    {
    }
}