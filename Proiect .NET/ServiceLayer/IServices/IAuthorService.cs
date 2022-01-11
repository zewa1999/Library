// <copyright file="IAuthorService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface IAuthorService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Author}" />.
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Author}" />
    public interface IAuthorService : IBaseService<Author>
    {
    }
}