// <copyright file="IBookService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface IBookService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Book}" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Book}" />.
    public interface IBookService : IBaseService<Book>
    {
    }
}