// <copyright file="IBorrowerService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface IBorrowerService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Borrower}" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Borrower}" />
    public interface IBorrowerService : IBaseService<Borrower>
    {
    }
}