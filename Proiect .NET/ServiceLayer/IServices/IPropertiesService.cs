// <copyright file="IPropertiesService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.IServices
{
    using Library.DomainLayer;

    /// <summary>
    /// Interface IPropertiesService
    /// Implements the <see cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Properties}" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.IServices.IBaseService{Library.DomainLayer.Properties}" />
    public interface IPropertiesService : IBaseService<Properties>
    {
    }
}