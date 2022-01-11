// <copyright file="AuthorService.cs" company="Transilvania University of Brasov">
// Costache Stelian-Andrei
// </copyright>

namespace Library.ServiceLayer.Services
{
    using Library.DataLayer.Interfaces;
    using Library.DataLayer.Validators;
    using Library.DomainLayer;
    using Library.ServiceLayer.IServices;
    using Proiect_.NET.Injection;

    /// <summary>
    /// Class AuthorService.
    /// Implements the <see cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Author, Library.DataLayer.Interfaces.IAuthorRepository}" />
    /// Implements the <see cref="Library.ServiceLayer.IServices.IAuthorService" />
    /// </summary>
    /// <seealso cref="Library.ServiceLayer.Services.BaseService{Library.DomainLayer.Author, Library.DataLayer.Interfaces.IAuthorRepository}" />
    /// <seealso cref="Library.ServiceLayer.IServices.IAuthorService" />
    public class AuthorService : BaseService<Author, IAuthorRepository, IPropertiesRepository>, IAuthorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService" /> class.
        /// </summary>
        public AuthorService()
            : base(Injector.Create<IAuthorRepository>(), Injector.Create<IPropertiesRepository>())
        {
            this.validator = new AuthorValidator();
        }
    }
}