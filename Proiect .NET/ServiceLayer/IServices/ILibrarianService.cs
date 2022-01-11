// <copyright file="ILibrarianService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer.Person;

    /// <summary>
    /// Interface ILibrarianService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Librarian}" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Person.Librarian}" />
    public interface ILibrarianService : IBaseService<Librarian>
    {
    }
}